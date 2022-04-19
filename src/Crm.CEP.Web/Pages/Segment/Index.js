$(document).ready(function () {
    /* dataTable.ajax.reload();*/

    $('#fltr_createddate').daterangepicker({
        startDate: filterDateRange.start,
        endDate: filterDateRange.end,
        opens: 'right',
        dateLimit: {
            'months': 12,
            'days': -1
        }
    }, SetDateRangeFilter);

    SetDateRangeFilter(filterDateRange.start, filterDateRange.end);

    var editSegment = new abp.ModalManager(abp.appPath + 'Segment/EditSegment');

    crm.cEP.segments.segment.getList({}).done(function (result) {
       
        $.each(result.items, function (key, value) {
            $('#fltr_segment').append($("<option></option>")
                .attr("value", value.id + "")
                .text(value.name));

        });
    
    });



    var segmentvar = {}
    segmentvar.segmentText = '';
    segmentvar.startDate = filterDateRange.start;
    segmentvar.endDate = filterDateRange.end;

    crm.cEP.segments.segment.filterSegment(segmentvar).done(function (result) {

        console.log("------------------", result);
    });

    $(document).on('change', '#fltr_segment', function () {


    });


    $(document).on('click', '#Searchbtn', function () {
        if ($("#fltr_segment").val()>0)
            segmentvar.segmentText = $("#fltr_segment option:selected").text();

        segmentvar.startDate = filterDateRange.start;
        segmentvar.endDate = filterDateRange.end;
      
        dataTable.ajax.reload();
       
    });
   
    
    var dataTable = $('#SegmentsTable').DataTable(      
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
           ajax: abp.libs.datatables.createAjax(crm.cEP.segments.segment.filterSegment, function () { return segmentvar;}),
            columnDefs: [
                {
                    title: "Actions",
                    rowAction: {
                        items:
                            [
                                {
                                    text: "Edit",
                                    action: function (data) {
                                        editSegment.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: "Delete",
                                    
                                    confirmMessage: function (data) {
                                        return (
                                            "Delete " + data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        crm.cEP.segments.segment
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    "SuccessfullyDeleted"
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: "ID",
                    data: "id"
                },
                {
                    title: "Segment Name",
                    data: "name"
                },
                {
                    title: "Creation Date",
                    data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                }

            ]
        })
    
    );
    editSegment.onResult(function () {
        dataTable.ajax.reload();
    });
});
var filterDateRange = {
    start: moment().subtract(30, 'days'),
    end: moment()
};
var _dateFormat = 'YYYY-MM-DD hh:mm:ss A';
function SetDateRangeFilter(start, end) {
    $('#fltr_createddate span').html(start.format('DD/MM/YYYY') + ' - ' + end.format('DD/MM/YYYY'));
   

    filterDateRange.start = start.format('YYYY-MM-DD');
    filterDateRange.end = end.format('YYYY-MM-DD');
    }
