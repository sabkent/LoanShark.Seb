using System.Configuration;
using System.Data.SqlClient;
using System.Transactions;
using LoanShark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace LoanShark.Infrastructure
{
    public sealed class SqlEventStore : IEventStore
    {
        public void StoreEvents(Guid streamId, IEnumerable<IEvent> events, long expectedInitialVersion)
        {
            var serializedEvents =
                events.Select(x => new Tuple<string, string>(x.GetType().FullName, JsonConvert.SerializeObject(x)));

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString))
            {
                connection.Open();

                const string commandText = "SELECT TOP 1 CurrentSequence FROM dbo.Stream WHERE StreamId = @StreamId;";
                long? existingSequence;
                using (var command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("StreamId", streamId.ToString());
                    var current = command.ExecuteScalar();
                    existingSequence = current == null ? (long?)null : (long)current;

                    if (existingSequence != null && ((long)existingSequence) > expectedInitialVersion)
                        throw new Exception(""); //ConcurrencyException();
                }

                using (var transaction = new TransactionScope())
                {
                    var nextVersion = InsertEventsAndReturnLastVersion(streamId, connection, expectedInitialVersion,
                                                                       serializedEvents);
                    if (existingSequence == null)
                        StartNewSequence(streamId, nextVersion, connection);
                    else
                        UpdateSequence(streamId, expectedInitialVersion, nextVersion, connection);
                    
                    transaction.Complete();
                }
            }
        }

        public IEnumerable<IEvent> LoadEvents(Guid id, long version = 0)
        {
            return null;
        }

        private long InsertEventsAndReturnLastVersion(Guid streamId, SqlConnection connection, long nextVersion,
                                              IEnumerable<Tuple<string, string>> serializedEvents)
        {
            foreach (var @event in serializedEvents)
            {
                const string insertCommandText = "INSERT INTO dbo.[Event] (EventId, StreamId, Sequence, TimeStamp, EventType, Body) VALUES (@EventId, @StreamId, @Sequence, @TimeStamp, @EventType, @Body);";
                using (var command = new SqlCommand(insertCommandText, connection))
                {
                    command.Parameters.AddWithValue("EventId", Guid.NewGuid());
                    command.Parameters.AddWithValue("StreamId", streamId.ToString());
                    command.Parameters.AddWithValue("Sequence", ++nextVersion);
                    command.Parameters.AddWithValue("TimeStamp", DateTime.UtcNow);
                    command.Parameters.AddWithValue("EventType", @event.Item1);
                    command.Parameters.AddWithValue("Body", @event.Item2);

                    command.ExecuteNonQuery();
                }
            }
            return nextVersion;
        }

        private void StartNewSequence(Guid streamId, long nextVersion, SqlConnection connection)
        {
            const string commandText =
                "INSERT INTO dbo.Stream (StreamId, CurrentSequence) VALUES (@StreamId, @CurrentSequence);";
            using (var command = new SqlCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("StreamId", streamId.ToString());
                command.Parameters.AddWithValue("CurrentSequence", nextVersion);

                var rows = command.ExecuteNonQuery();
                if (rows != 1)
                    throw new Exception(); //ConcurrencyException();
            }
        }

        private void UpdateSequence(Guid streamId, long expectedInitialVersion, long nextVersion, SqlConnection connection)
        {
            const string commandText =
                "UPDATE dbo.Stream SET CurrentSequence = @CurrentSequence WHERE StreamId = @StreamId AND CurrentSequence = @OriginalSequence;";
            using (var command = new SqlCommand(commandText, connection))
            {
                command.Parameters.AddWithValue("StreamId", streamId.ToString());
                command.Parameters.AddWithValue("CurrentSequence", nextVersion);
                command.Parameters.AddWithValue("OriginalSequence", expectedInitialVersion);

                var rows = command.ExecuteNonQuery();
                if (rows != 1)
                    throw new Exception(); //ConcurrencyException();
            }
        }

        //TODO: GLUDGEMUFFIN: multi bounded context
        private string _connectionStringName;
        public string ConnectionStringName
        {
            set { _connectionStringName = value; }
        }
    }
}
