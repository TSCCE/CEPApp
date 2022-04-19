$(document).ready(function () {
    $('#div_seg_op').hide();


    var equalsarray = (Object.values(EnumEqualsarray.equalsarray)).toString();
  
    //var equalsarray = ["nat", "gen", "ms", "itm"];
    /*var condition = ["dob", "doj", "pd", "inv", "atv", "upt"];*/
    //var operators = [{"code": "eq", "value": "Equal To"},
    //{"code":"gt","value":"Greater Than/Equal To"},
    //{"code":"lt","value":"Less Than/Equal To"},
    //    { "code": "bt", "value": "Between" }];

    var operators = (Object.values(EnumOperators.operators)).toString();

    var operators = [{ "code": operators[0][0], "value": "Equal To" },
    { "code": operators[0][1], "value": "Greater Than/Equal To" },
    { "code": operators[0][2], "value": "Less Than/Equal To" },
    { "code": operators[0][3], "value": "Between" }];

   
   /*   var dropdwn = ["itm", "nat", "gen", "ms"];*/

    var dropdwn = (Object.values(EnumDropdown.dropdwn)).toString();

    //var dateval = ["dob", "doj", "pd"];

    var dateval = (Object.values(EnumDateval.dateval)).toString();
   
    /*  var txt = ["inv", "atv", "upt"];*/
   


    $(document).on('change', '#seg_attr', function () {
        $('#seg_op').html('<option value = "0" >--Select--</option >');
        $('#div_seg_op').show();
        $("#seg_val").remove();
        if (equalsarray.indexOf($('#seg_attr').val()) != -1) {
            $('#seg_op').html('<option value="eq">Equal To</option>');

        }
        else {
            $.each(operators, function (key, value) {
                $('#seg_op').append($("<option></option>")
                    .attr("value", value.code + "")
                    .text(value.value));

            });
        }

        if (dropdwn.indexOf($('#seg_attr').val()) != -1) {
            var qhtml = '<div class="col-md-3" id="seg_val"><div class="form-group">' +
                '<select class="form-control select2" id="segment_val" style="width: 100%;">' +
                '<option value="0">--Select--</option></select></div></div>';
            $('#seg_parent').append(qhtml);
        }
        else {

           /* alert(dateval.indexOf($('#seg_attr').val()));*/

            if (dateval.indexOf($('#seg_attr').val()) != -1) {             
                var qhtml = '<div class="col-md-3" id="seg_val"><div class="form-group">' +
                    '<input id="segment_val" type="text" class="form-control datepicker" style="border-right: 1px solid #d2d6de;" />' +
                    /*  '<input type="text" class="form-control" id="datepicker" placeholder="dd/mm/yyyy" />'+*/
                    '</div></div>';
                $('#seg_parent').append(qhtml);
                $('.datepicker').datetimepicker({ format: "MM/DD/YYYY", showClose: true, showClear: true});


            }
            else {
                var qhtml = '<div class="col-md-3" id="seg_val"><div class="form-group">' +
                    '<input id="segment_val" type="text" class="form-control" />' +
                    '</div></div>';
                $('#seg_parent').append(qhtml);

            }


        }

    });

    $(document).on('change', '#seg_mode', function () {
        $('#seg_attr').html('<option value="0">--Select--</option>');     
        if ($('#seg_mode').val() == 1) {

            var segattri = Object.values(EnumSegattri.segattri);
           
            //var segattr = [{"code": "dob", "value": "DOB"},
            //    {"code": "nat", "value": "Nationality"},
            //    {"code": "gen", "value": "Gender"},
            //    {"code": "ms", "value": "Marital Status"},
            //    { "code": "doj", "value": "Date of Joining" },
            //    {"code":"pd","value": "Purchase Date"}];

            var segattr = [{ "code": segattri[0][0], "value": "DOB" },
            { "code": segattri[0][1], "value": "Nationality" },
            { "code": segattri[0][2], "value": "Gender" },
            { "code": segattri[0][3], "value": "Marital Status" },
            { "code": segattri[0][4], "value": "Date of Joining" },
            { "code": segattri[0][5], "value": "Purchase Date" }];
            $.each(segattr, function (key, value) {
                $('#seg_attr').append($("<option></option>")
                    .attr("value", value.code+ "")
                    .text(value.value));

            });
        }
        else {
            if ($('#seg_mode').val() == 2) {

                //var segattr = [{ "code": "inv", "value": "Invoice Value" },
                //{ "code": "itm", "value": "Item" },
                //{ "code": "atv", "value": "ATV" },
                //{ "code": "upt", "value": "UPT" }];

                var segattr = Object.values(EnumSegattr.segattr);
                var segattr = [{ "code": segattr[0][0], "value": "Invoice Value" },
                { "code": segattr[0][1], "value": "Item" },
                { "code": segattr[0][2], "value": "ATV" },
                { "code": segattr[0][3], "value": "UPT" }];


                $.each(segattr, function (key, value) {

                    $('#seg_attr').append($("<option></option>")
                        .attr("value", value.code+ "")
                        .text(value.value));

                });
            }
            else
                $('#seg_attr').html('<option value="0">--Select--</option>');

        }

    });


    $(document).on('click', '#AddMoreBtn', function () {


        var segmode = $("#seg_mode option:selected").text();
        var segattr = $("#seg_attr option:selected").text();
        var segop = $("#seg_op option:selected").text();
        var segval = $("#segment_val").val();



        var qhtml = '<tr><td>' + segmode + '</td>' +
            '<td>' + segattr + '</td>' +
            '<td>' + segop + '</td>' +
            '<td>' + segval + '</td>' +
            '<td><button class="remove_row"><i class="fa fa-trash" id ="rm"></i></button></td>' +
            //'<td>AND</td></tr>';
            '<td><select class="form-control select2" id="" style="width: 60%;">' +
            '<option value="AND">AND</option>' +
            '<option value="OR">OR</option>' +
            '</select></td></tr>';

        $('#Segment_Container').append(qhtml);
        $('#seg_mode').val(0).trigger('change');
        $('#seg_attr').html('<option value="0">--Select--</option>');
        $('#seg_op').html('<option value="0">--Select--</option>');
        $('#div_seg_op').hide();

        $("#seg_val").remove();

    });

    $("#Segment_Container").on("click", ".remove_row", function () {

        $(this).closest("tr").remove();
    });

    $(document).on("click", "#SaveSegBtn", function () {
        var segmentName = $("#seg_name").val();

        var filter = [];
        $('#Segment_Container tr').each(function () {
            filter.push({
                segmentMode: $(this).find("td").eq(0).html(),
                segmentAttribute: $(this).find("td").eq(1).html(),
                segmentOperation: $(this).find("td").eq(2).html(),
                segmentValue: $(this).find("td").eq(3).html(),
                nextCondition: $(this).find("td").eq(5).find(":selected").val()
            });


        });
        filter.splice(0, 1);

        jsonfilter=JSON.stringify(filter);
        console.log('--------filter-----' + jsonfilter);
        crm.cEP.segments.segment.create({
            Name: segmentName
        }).then(function (result) {



            console.log('successfully created segment:' + result.id);
            var segid = result.id;

            crm.cEP.queries.query.create({
                segmentId: segid,
                jsonQueryField: jsonfilter

            }).then(function (result) {
                console.log('successfully created query:' + result.id);
                $("#seg_name").val();
                $('#Segment_Container').html('');
                window.location.href = '/Segment/Index/';

            });
        });

    });
});