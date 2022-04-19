$(document).ready(function () {

   
    //crm.cEP.segments.segment.getList({}).done(function (result) {

    //    $.each(result.items, function (key, value) {
    //        $('#fltr_segment').append($("<option></option>")
    //            .attr("value", value.id + "")
    //            .text(value.name));

    //    });

    //});


    $(document).on("click", "#Mapbtn", function () {
      
        //$.ajax({
        //   // async: false,
        //    url: "/WorkFlowSignal/JourneyMap",
        //   // dataType: "json",
        //    success: function (data) {  }
        //});
        var journey = $('#fltr_journey option:selected').text();
        

        //workflowMap(journey, false).then(function (data) {
            
        //});
        workflowMap(journey);
    });



    function workflowMap(callBack) {
        $.ajax({
            url: '/WorkFlowSignal/JourneyMap',
            data: { Test: callBack }
        }).done(callBack);
    }


});