﻿using LoanShark.Application.Origination.Events;
using LoanShark.Messaging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;

namespace LoanShark.Application.Origination.EventSubscribers
{
    public class LoanApplicationCompleteSignaler : ISubscribeToEvent<LoanApplicationAccepted>
    {
        public async void Notify(LoanApplicationAccepted @event)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));

            using (var httpClient = new HttpClient()) //use factory to buld httpclient which sets auth token etc
            {
                //TODO: how to manage uri for apis.  ApiEndpointFactory.GetFor(EndPoints.Originration)

                //http://www.thomaslevesque.com/tag/httpcontent/
                //assembly ref for PushStreamContent: System.Net.Http.Formatting
                var content = new PushStreamContent((stream, httpContent, transportContext) =>
                {
                    var serializer = new JsonSerializer();
                    using (var writer = new StreamWriter(stream))
                        serializer.Serialize(writer, @event);
                });
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await httpClient.PostAsync("http://localhost:12277/api/event/loan-application-accepted", content);
            }
        }
    }
}