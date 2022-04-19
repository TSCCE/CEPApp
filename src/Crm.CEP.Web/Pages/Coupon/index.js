$(function () {


    var dataTable = $('#CouponsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(crm.cEP.createCoupon),
            columnDefs: [
                {
                    title: ('Name'),
                    data: "name"
                },
                {
                    title: ('Type'),
                    data: "type",
                    render: function (data) {
                        return ('Enum:Status:' + data);
                    }
                },
                {
                    title: ('CreationTime'),
                    data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: ('LastModificationTime'), data: "lastModificationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    var createCoupon = new abp.ModalManager(abp.appPath + 'Coupon/CreateCoupon');

    createCoupon.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewCouponButton').click(function (e) {
        e.preventDefault();
        createCoupon.open();
    });
});