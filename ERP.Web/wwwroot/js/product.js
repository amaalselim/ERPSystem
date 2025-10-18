$(function () {
    //$('#CategoryId, #BranchId').select2();

    var dataTable = $('#js-ProductsTable').DataTable({
        processing: false,
        serverSide: true,
        info: false,
        autoWidth: true,
        searching: false,
        responsive: true,
        "jQueryUI": true,
        ajax: {
            "url": '/Products/GetProducts',
            "type": 'POST',
            "contentType": 'application/x-www-form-urlencoded; charset=UTF-8',
            "data": function (d) {
                d.NameSearch = $('#NameSearch').val();
                d.CategoryId = $('#CategoryId').val();
                d.BranchId = $('#BranchId').val();
                d.UnitId = $('#UnitId').val();

            }
        },
        columns: [
            {data: 'id'},
            {
                data: 'name',
                render: function (data, type, row) {
                    return `<strong>${data}</strong>`;
                }
            },
            {
                data: 'categoryName',
                render: function (data, type, row) {
                    return `<strong>${data}</strong>`;
                }
            },
            {
                data: 'unitName',
                render: function (data, type, row) {
                    return `<strong>${data}</strong>`;
                }
            },
            {
                data: 'branchName',
                render: function (data, type, row) {
                    return `<strong>${data}</strong>`; 
                }
            },
            {
                data: 'price',
                render: function (data, type, row) {
                    return `<strong>${data} EGP</strong>`;
                }
            }
        ]
    });

    $('#NameSearch').on('keyup', function () { dataTable.ajax.reload(); });
    $('#CategoryId, #BranchId,#UnitId').on('change', function () { dataTable.ajax.reload(); });

});