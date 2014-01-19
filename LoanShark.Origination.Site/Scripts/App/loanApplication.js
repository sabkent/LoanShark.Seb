(function ($) {
    $(function () {
        //var appForm = new ApplicationForm($('#applyCommand'));
        //$('#applyCommand').on('click', appForm.submitCommand);
    });

    function applyCommand(e) {
        e.preventDefault();
        var form = $(this).parent('form');

        $.ajax({
            url: '/apply/ValidateFromClient',
            type: 'POST',
            data: form.serialize()
        }).success(applyCommandSuccess)
          .error(applyCommandError);
    };

    function applyCommandSuccess(data) {
        if (data.IsValid){
            console.log("valid");
        }
        else {
            $(data.Errors).each(function() {
                console.log($(this));
            });
        }
    };

    function applyCommandError(data) {
        console.log('errror');
    };

}(jQuery));


function ApplicationForm(submitCommand) {
    this.self = this;
    this.submitCommand = submitCommand;
};

ApplicationForm.prototype = function() {

    function submitCommandEventHandler(e) {
        e.preventDefault();
        console.log('adkhjfalsjfhadhfaldf');
    };

    return
    {
        submitCommand: submitCommandEventHandler
    };
}();