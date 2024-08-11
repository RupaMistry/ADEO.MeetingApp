// AttendeesAction Datatable

$(document).ready(() => {

    toastr.options = {
        closeButton: true,
        debug: false,
        newestOnTop: true,
        progressBar: true,
        positionClass: "toast-top-right",
        preventDuplicates: false,
        onclick: null,
        showDuration: "300",
        hideDuration: "1000",
        timeOut: "5000",
        extendedTimeOut: "1000",
        showEasing: "swing",
        hideEasing: "linear",
        showMethod: "fadeIn",
        hideMethod: "fadeOut",
    };

    setTimeout(function () {
        var table = $("#attendeesList").DataTable({
            responsive: true,
        });
    }, 2000);

    function isValid(meetingID, attendeeID) {

        if (meetingID <= 0) alert("Invalid meetingID");
        else if (attendeeID <= 0) alert("Invalid attendeeID");
        else return true;
    }

    $('.startCall').on("click", function () {
        const meetingID = $(this).attr('meetingID');
        const attendeeID = $(this).attr('attendeeID');

        if (!isValid(meetingID, attendeeID)) {
            return;
        }

        var url = "AttendeesAction/StartCallRequest?meetingID=" + meetingID + "&attendeeID=" + attendeeID;
        var jqxhr = $.post(url, function () { })
            .done(function (response) {
                if (response >= 0) {
                    $('#txtCall_' + attendeeID).text('True');
                    $('#btnCall_' + attendeeID).attr("disabled", "disabled");
                    $('#btnEndCall_' + attendeeID).removeAttr('disabled');

                    var name = $('#txtName_' + attendeeID).text();;
                    toastr["success"](
                        name + " called successfully!"
                    );
                }
            })
            .fail(function (error) {
                toastr["error"](error);
            })
    });

    $('.endCall').on("click", function () {
        const meetingID = $(this).attr('meetingID');
        const attendeeID = $(this).attr('attendeeID');

        if (!isValid(meetingID, attendeeID)) {
            return;
        }

        var url = "AttendeesAction/EndCallRequest?meetingID=" + meetingID + "&attendeeID=" + attendeeID;
        var jqxhr = $.post(url, function () { })
            .done(function (response) {
                if (response >= 0) {
                    $('#btnEndCall_' + attendeeID).attr("disabled", "disabled");

                    var name = $('#txtName_' + attendeeID).text();;
                    toastr["success"](
                        "Call ended successfully for " + name + "!"
                    );
                }
            })
            .fail(function (error) {
                toastr["error"](error);
            });
    });
});