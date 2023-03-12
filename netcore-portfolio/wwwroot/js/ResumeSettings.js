
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

$(document).ready(function () {

        $.ajax({
            type: "GET",
            url: "/ResumeSettings/GetService",
            dataType: "json",
            success: function (data) {
                $.each(data, function (i, service) {
                    var card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
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
                        '<a href="#" class="btn btn-sm btn-warning">' +
                        '<i class="fas fa-pen"></i> Düzenle' +
                        '</a>' +
                        '<a href="#" class="btn btn-sm btn-danger">' +
                        '<i class="fas fa-trash"></i> Sil' +
                        '</a>' +
                        '</div>' +
                        '</div>' +
                        '</div>' +
                        '</div>';
                    $('#service-cards').append(card);
                });
            },
            error: function () {
                alert("Error retrieving services.");
            }
        });


    
});