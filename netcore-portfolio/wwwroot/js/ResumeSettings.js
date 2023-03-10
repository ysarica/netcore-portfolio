$(function () {
    $('[data-toggle="switch"]').bootstrapSwitch();

    $('[data-toggle="switch"]').on('switchChange.bootstrapSwitch', function (event, state) {
        var id = $(this).data('id');
        var value = $(this).data('value');
        $.ajax({
            type: 'POST',
            url: '/ResumeSettings/UpdateResumeSwitcs',
            data: { id: id, value: state },
            success: function (result) {
                console.log(result);
            }
        });
    });
});
function getResumeData() {
    $.ajax({
        type: 'GET',
        url: '/ResumeSettings/GetResume/',
        success: function (resume) {
            $('#name').val(resume.name);
            $('#surname').val(resume.surname);
            $('#titleDescription').val(resume.titleDescription);
            $('#title').val(resume.title);
            $('#phone').val(resume.phone);
            $('#mail').val(resume.mail);
            $('#location').val(resume.location);
            $('#resumeAbout').val(resume.resumeAbout);
            $('#resumeimage').attr('src', resume.resumeImage);
            $('#resumeCvD').attr('href', resume.pdfCV);
            $('#resumeCvV').attr('href', resume.pdfCV);


            $('#workstate').bootstrapSwitch('state', resume.workState);
            $('#services').bootstrapSwitch('state', resume.serviceState);
            $('#workprocces').bootstrapSwitch('state', resume.workProccesState);

            getService()
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Özgeçmiş Bilgi Düzenleme',
                text: 'Malesef Bir Hata Oluştu,verilere ulaşamıyoruz.'
            });
        }
    });
}

$('#updateButton').click(function (e) {
    e.preventDefault();
    var model = {
        name: $('#name').val(),
        surname: $('#surname').val(),
        titleDescription: $('#titleDescription').val(),
        title: $('#title').val(),
        phone: $('#phone').val(),
        mail: $('#mail').val(),
        location: $('#location').val(),
        resumeAbout: $('#resumeAbout').val()
    };

    $.ajax({
        type: 'POST',
        url: '/ResumeSettings/UpdateResume',
        data: model,
        success: function (response) {
            if (response.success) {
                getResumeData();
                Swal.fire({
                    position: 'top-end',
                    icon: 'success',
                    title: 'Özgeçmiş Genel Bilgiler Başarıyla Güncellendi',
                    showConfirmButton: false,
                    timer: 1500
                })
            } else {
                Swal.fire({
                    icon: 'danger',
                    title: 'Özgeçmiş Bilgi Düzenleme',
                    text: 'Malesef Bir Hata Oluştu,verilere ulaşamıyoruz.'
                });
            }
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Özgeçmiş Bilgi Düzenleme',
                text: 'Malesef Bir Hata Oluştu,verilere ulaşamıyoruz.'
            });
        }
    });
});

$('#saveResumeImage').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('file', $('#resumeImage')[0].files[0]);

    $.ajax({
        url: '/ResumeSettings/ResumeImageUpdate',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.success) {
                getResumeData();
                Swal.fire({
                    icon: 'success',
                    title: 'Resim Yükleme',
                    text: 'Resim başarıyla yüklendi'
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Resim Yükleme',
                    text: 'Resim yüklenirken bir hata oluştu'
                });
            }
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                title: 'Resim Yükleme',
                text: 'Resim yüklenirken bir hata oluştu'
            });
        }
    });
});

$('#saveResumeCv').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('file', $('#resumeCv')[0].files[0]);

    $.ajax({
        url: '/ResumeSettings/ResumeCvUpdate',
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.success) {
                getResumeData();
                Swal.fire({
                    icon: 'success',
                    title: 'Cv Yükleme',
                    text: 'Cv başarıyla yüklendi'
                });
            } else {
                Swal.fire({
                    icon: 'error',
                    title: 'Cv Yükleme',
                    text: 'Cv yüklenirken bir hata oluştu'
                });
            }
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'error',
                title: 'Cv Yükleme',
                text: 'Cv yüklenirken bir hata oluştu'
            });
        }
    });
});

function getServiceData() {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetService",
        success: function (data) {
            var card = '';
            $('#service-cards').empty();
            $.each(data, function (i, service) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center">' + service.serviceName + '</div>' +
                    '<div class="card-body pt-0">' +
                    '<div class="row">' +
                    '<div class="col-12 text-center">' +
                    '<img src="' + service.serviceImage + '" alt="user-avatar" class="img-circle img-fluid">' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm">' + service.serviceDescription + '</p>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +                   
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deleteService(' + service.serviceID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#service-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Sunduğunuz Hizmetler',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addServiceButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('ResumeID', $('#ResumeID').val());
    formData.append('ServiceImage', $('#ServiceImage')[0].files[0]);
    formData.append('ServiceName', $('#ServiceName').val());
    formData.append('ServiceDescription', $('#ServiceDescription').val());

    // AJAX kullanarak verileri post et
    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddService",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            console.log(data);
            getServiceData();
            Swal.fire({
                icon: 'success',
                title: 'Sunduğunuz Hizmetler',
                text: 'Hizmet Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'Sunduğunuz Hizmetler',
                text: 'Bir Hata Oluştu !'
            });
        }
    });
});

function deleteService(serviceId) {
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
                url: '/ResumeSettings/DeleteService',
                data: { 'id': serviceId },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Hizmet başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getServiceData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Hizmet silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Hizmet silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}


