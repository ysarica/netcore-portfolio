//PortfolioCategory Start
function getPortfolioCategoryData() {
    $.ajax({
        type: "GET",
        url: "/Portfolio/GetPortfolioCategory/",
        success: function (data) {
            var card = '';
            $('#pCategory-cards').empty();
            $.each(data, function (i, pCategory) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center">' + pCategory.pCategoryName + '</div>' +
                   
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editPCategory(' + pCategory.pCategoryID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deletePCategory(' + pCategory.pCategoryID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#pCategory-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Portfolyo Kategori',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addPortfolioCategoryButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('PCategoryName', $('#PCategoryName').val());

    $.ajax({
        type: "POST",
        url: "/Portfolio/AddPortfolioCategory",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addPortfolioCategory').modal('hide');
            console.log(data);
            getPortfolioCategoryData();
            $('#PCategoryName').val('');
            Swal.fire({
                icon: 'success',
                title: 'Portfolyo Kategori',
                text: 'Kategori Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'Portfolyo Kategori',
                text: 'Bir Hata Oluştu !'
            });
        }
    });
});

function deletePCategory(pCategoryID) {
    Swal.fire({
        title: 'Emin misiniz?',
        text: "Bu işlemi geri alamazsınız!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Evet, sil!',
        cancelButtonText: 'İptal'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Portfolio/DeletePortfolioCategory',
                data: { 'id': pCategoryID },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Kategori başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getPortfolioCategoryData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Kategori silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Kategori silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}

function editPCategory(serviceID) {
    $.ajax({
        type: "GET",
        url: "/Portfolio/GetPortfolioCategoryById/" + serviceID,
        success: function (data) {
            $('#PCategoryNameU').val(data.pCategoryName);
            $('#PCategoryID').val(data.pCategoryID);

            $('#modal-updatePortfolioCategory').modal('show');

            $('#update-portfoliocategory-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();

                formData.append('PCategoryName', $('#PCategoryNameU').val());
                formData.append('PCategoryID', $('#PCategoryID').val());

                $.ajax({
                    type: "POST",
                    url: "/Portfolio/UpdatePortfolioCategory/",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updatePortfolioCategory').modal('hide');
                        getPortfolioCategoryData();
                        serviceID = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'Portfolyo Kategori',
                            text: 'Kategori Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Portfolyo Kategori',
                            text: 'Kategori güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Portfolyo Kategori',
                text: 'Kategori verileri getirilirken bir hata oluştu.'
            });
        }
    });
}
//PortfolioCategory Finish