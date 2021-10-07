﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/CoverType/GetAll"
        },
        "columns": [
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Admin/CoverType/FormCoverType/${data}" class="btn btn-success" style ="cursor:pointer">
                                <i class="fas fa-edit"></i> Edit
                            </a>
                            <a onclick=Delete("/Admin/CoverType/Delete/${data}") class="btn btn-danger" style="cursor:pointer">
                                <i class="fas fa-trash-alt"></i> Delete
                            </a>
                        </div> 
                    `;
                }, "width": "40%"
            }
        ]
    });
}

function Delte(url){
    swal.fire({
        title: "Are you sure you want to delete?",
        text: "This will delete the data permanently.",
        dangerMode: true,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!',
        showClass: {
            popup: 'animate__animated animate__fadeInDown'
        },
        hideClass: {
            popup: 'animate__animated animate__fadeOutUp'
        }
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}