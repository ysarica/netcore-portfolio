
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
