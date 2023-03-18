﻿$(function () {
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
            $('#workState').bootstrapSwitch('state', resume.workState);
            $('#serviceState').bootstrapSwitch('state', resume.serviceState);
            $('#workProccesState').bootstrapSwitch('state', resume.workProccesState);
            $('#workPartnersState').bootstrapSwitch('state', resume.workPartnersState);
            $('#hobbiesState').bootstrapSwitch('state', resume.hobbiesState);
            $('#workHistoryState').bootstrapSwitch('state', resume.workHistoryState);
            $('#educationState').bootstrapSwitch('state', resume.educationState);
            $('#testimonialState').bootstrapSwitch('state', resume.testimonialState);

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
//Services Start
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
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editService(' + service.serviceID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
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

    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddService",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addService').modal('hide');
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

function editService(serviceID) {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetServiceById/" + serviceID,
        success: function (data) {
            var fileUpload = document.getElementById("ServiceImageU");
            fileUpload.form.reset();
            $('#ServiceNameU').val(data.serviceName);
            $('#ServiceDescriptionU').val(data.serviceDescription);
            $('#ServiceImageVU').attr('src', data.serviceImage);
            $('#ServiceID').val(data.serviceID);

            $('#modal-updateService').modal('show');

            $('#update-service-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();
                formData.append('ServiceImage', $('#ServiceImageU')[0].files[0]);
                formData.append('ServiceName', $('#ServiceNameU').val());
                formData.append('ServiceDescription', $('#ServiceDescriptionU').val());
                formData.append('ServiceID', $('#ServiceID').val());

                $.ajax({
                    type: "POST",
                    url: "/ResumeSettings/UpdateService/",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updateService').modal('hide');
                        getServiceData();
                        serviceID = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'Sunduğunuz Hizmetler',
                            text: 'Hizmet Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Hizmet Güncelleme Hatası',
                            text: 'Hizmet güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Hizmet Getirme Hatası',
                text: 'Hizmet verileri getirilirken bir hata oluştu.'
            });
        }
    });
}
//Services Stop
//Procces Start
function getProccesData() {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetProcces",
        success: function (data) {
            var card = '';
            $('#procces-cards').empty();
            $.each(data, function (i, procces) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center">' + procces.wpName + '</div>' +
                    '<div class="card-body pt-0">' +
                    '<div class="row">' +
                    '<div class="col-12 text-center">' +
                    '<img src="' + procces.wpImage + '" alt="user-avatar" class="img-circle img-fluid">' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Sıralama Sırası</b>: ' + procces.wpOrder + '</p>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editProcces(' + procces.workProcesID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deleteProcces(' + procces.workProcesID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#procces-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Çalışma Süreçleriniz ',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addProccesButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('ResumeID', $('#ResumeID').val());
    formData.append('WpImage', $('#WpImage')[0].files[0]);
    formData.append('WpName', $('#WpName').val());
    formData.append('WpOrder', $('#WpOrder').val());

    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddProcces",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addProcces').modal('hide');
            console.log(data);
            getProccesData();
            Swal.fire({
                icon: 'success',
                title: 'Çalışma Süreciniz',
                text: 'Süreç Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'Çalışma Süreciniz',
                text: 'Bir Hata Oluştu !'
            });
        }
    });
});

function deleteProcces(proccesId) {
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
                url: '/ResumeSettings/DeleteProcces',
                data: { 'id': proccesId },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Süreç başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getProccesData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Süreç silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Süreç silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}

function editProcces(proccesId) {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetProccesById/" + proccesId,
        success: function (data) {
            var fileUpload = document.getElementById("WpImageU"); fileUpload.form.reset();
            $('#WpNameU').val(data.wpName);
            $('#WpOrderU').val(data.wpOrder);
            $('#WpImageVU').attr('src', data.wpImage);
            $('#WorkProcesID').val(data.workProcesID);

            $('#modal-updateProcces').modal('show');

            $('#update-procces-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();
                formData.append('WpImage', $('#WpImageU')[0].files[0]);
                formData.append('WpName', $('#WpNameU').val());
                formData.append('WpOrder', $('#WpOrderU').val());
                formData.append('workProcesID', $('#WorkProcesID').val());

                $.ajax({
                    type: "POST",
                    url: "/ResumeSettings/UpdateProcces/",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updateProcces').modal('hide');
                        getProccesData();
                        proccesId = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'Çalışma Süreciniz',
                            text: 'Süreciniz Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Çalışma Süreciniz Hatası',
                            text: 'Çalışma Süreciniz güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Çalışma Süreciniz Hatası',
                text: 'Çalışma Süreciniz verileri getirilirken bir hata oluştu.'
            });
        }
    });
}
//Procces Stop
//Partners Start
function getPartnersData() {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetPartners",
        success: function (data) {
            var card = '';
            $('#partners-cards').empty();
            $.each(data, function (i, partners) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center">' + partners.wpsName + '</div>' +
                    '<div class="card-body pt-0">' +
                    '<div class="row">' +
                    '<div class="col-12 text-center">' +
                    '<img src="' + partners.wpsLogo + '" alt="user-avatar" class="img-circle img-fluid">' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editPartners(' + partners.workPartnersID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deletePartners(' + partners.workPartnersID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#partners-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'İş Ortaklarınız',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addPartnersButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('ResumeID', $('#ResumeID').val());
    formData.append('WpsLogo', $('#WpsLogo')[0].files[0]);
    formData.append('WpsName', $('#WpsName').val());

    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddPartners",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addPartners').modal('hide');
            console.log(data);
            getPartnersData();

            Swal.fire({
                icon: 'success',
                title: 'İş Ortaklarınız',
                text: 'Ortak Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'İş Otaklarınız',
                text: 'Bir Hata Oluştu !'
            });
        }
    });
});

function deletePartners(partnersID) {
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
                url: '/ResumeSettings/DeletePartners',
                data: { 'id': partnersID },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Ortak başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getPartnersData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Ortak silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Ortak silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}
function editPartners(partnersID) {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetPartnersById/" + partnersID,
        success: function (data) {
            var fileUpload = document.getElementById("WpsLogoU");
            fileUpload.form.reset();
            $('#WorkPartnersID').val(data.workPartnersID);
            $('#WpsNameU').val(data.wpsName);
            $('#WpsLogoVU').attr('src', data.wpsLogo);
            $('#modal-updatePartners').modal('show');
            $('#update-partners-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();
                formData.append('WpsLogo', $('#WpsLogoU')[0].files[0]);
                formData.append('WpsName', $('#WpsNameU').val());
                formData.append('WorkPartnersID', $('#WorkPartnersID').val());
                $.ajax({
                    type: "POST",
                    url: "/ResumeSettings/UpdatePartners/",
                    data:formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updatePartners').modal('hide');
                        getPartnersData();
                        partnersID = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'İş Ortaklarınız',
                            text: 'Ortak Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'İş Ortaklarınız',
                            text: 'Ortak güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'İş Ortaklarınız',
                text: 'Ortak verileri getirilirken bir hata oluştu.2'
            });
        }
    });
}
//Partners Stop
//Hobbies Start
function getHobbiesData() {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetHobbies",
        success: function (data) {
            var card = '';
            $('#hobbie-cards').empty();
            $.each(data, function (i, hobbies) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center">' + hobbies.hobbieName + '</div>' +
                    '<div class="card-body pt-0">' +
                    '<div class="row">' +
                    '<div class="col-12 text-center">' +
                    '<img src="' + hobbies.hobbieImage + '" alt="user-avatar" class="img-circle img-fluid">' +
                    '</div>' +              
                    '</div>' +
                    '</div>' +
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editHobbies(' + hobbies.hobbieID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deleteHobbies(' + hobbies.hobbieID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#hobbie-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Hobileriniz',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addHobbiesButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('ResumeID', $('#ResumeID').val());
    formData.append('HobbieImage', $('#HobbieImage')[0].files[0]);
    formData.append('HobbieName', $('#HobbieName').val());

    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddHobbies",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addHobbies').modal('hide');
            console.log(data);
            getHobbiesData();

            Swal.fire({
                icon: 'success',
                title: 'Hobileriniz',
                text: 'Hobi Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'Hobileriniz',
                text: 'Bir Hata Oluştu !'
            });
        }
    });
});

function deleteHobbies(hobbieID) {
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
                url: '/ResumeSettings/DeleteHobbies',
                data: { 'id': hobbieID },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Hobi başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getHobbiesData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Hobi silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Hobi silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}

function editHobbies(hobbieID) {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetHobbiesById/" + hobbieID,
        success: function (data) {
            var fileUpload = document.getElementById("HobbieImageU"); fileUpload.form.reset();
            $('#HobbieNameU').val(data.hobbieName);
            $('#HobbieImageVU').attr('src', data.hobbieImage);
            $('#HobbieID').val(data.hobbieID);

            $('#modal-updateHobbies').modal('show');

            $('#update-hobbie-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();
                formData.append('HobbieImage', $('#HobbieImageU')[0].files[0]);
                formData.append('HobbieName', $('#HobbieNameU').val());
                formData.append('HobbieID', $('#HobbieID').val());

                $.ajax({
                    type: "POST",
                    url: "/ResumeSettings/UpdateHobbies/",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updateHobbies').modal('hide');
                        getHobbiesData();
                        hobbieID = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'Hobileriniz',
                            text: 'Hobi Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Hobileriniz',
                            text: 'Hobi güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Hobileriniz',
                text: 'Hobi verileri getirilirken bir hata oluştu.'
            });
        }
    });
}
//Hobbies Stop
//WHistory Start
function getHistoryData() {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetHistory",
        success: function (data) {
            var card = '';
            $('#history-cards').empty();
            $.each(data, function (i, history) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center"><b>Firma:</b>:' + history.companyName + '</div>' +
                    '<div class="card-body pt-0">' +
                    '<div class="row">' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Giriş Tarihi:</b>: ' + history.startDate + '</p>' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Çıkış Tarihi:</b>: ' + history.finishDate + '</p>' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Pozisyon:</b>: ' + history.workTitle + '</p>' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>İş Açıklaması:</b>: ' + history.workDescription + '</p>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editHistory(' + history.workHistoryID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deleteHistory(' + history.workHistoryID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#history-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Tecrübeleriniz',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addHistoryButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('ResumeID', $('#ResumeID').val());
    formData.append('StartDate', $('#StartDate').val());
    formData.append('FinishDate', $('#FinishDate').val());
    formData.append('WorkTitle', $('#WorkTitle').val());
    formData.append('CompanyName', $('#CompanyName').val());
    formData.append('WorkDescription', $('#WorkDescription').val());

    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddHistory",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addHistory').modal('hide');
            console.log(data);
            getHistoryData();

            Swal.fire({
                icon: 'success',
                title: 'Tecrübeleriniz',
                text: 'Tecrübe Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'Tecrübeleriniz',
                text: 'Bir Hata Oluştu !'
            });
        }
    });
});

function deleteHistory(historyID) {
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
                url: '/ResumeSettings/DeleteHistory',
                data: { 'id': historyID },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Tecrübe başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getHistoryData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Tecrübe silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Tecrübe silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}

function editHistory(historyID) {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetHistoryById/" + historyID,
        success: function (data) {
            $('#StartDateU').val(data.startDate);
            $('#FinishDateU').val(data.finishDate);
            $('#WorkTitleU').val(data.workTitle);
            $('#CompanyNameU').val(data.companyName);
            $('#WorkDescriptionU').val(data.workDescription);
            $('#WorkHistoryID').val(data.workHistoryID);

            $('#modal-updateHistory').modal('show');

            $('#update-history-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();
                formData.append('StartDate', $('#StartDateU').val());
                formData.append('FinishDate', $('#FinishDateU').val());
                formData.append('WorkTitle', $('#WorkTitleU').val());
                formData.append('CompanyName', $('#CompanyNameU').val());
                formData.append('WorkDescription', $('#WorkDescriptionU').val());
                formData.append('WorkHistoryID', $('#WorkHistoryID').val());

                $.ajax({
                    type: "POST",
                    url: "/ResumeSettings/UpdateHistory/",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updateHistory').modal('hide');
                        getHistoryData();
                        hobbieID = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'Tecrübeleriniz',
                            text: 'Tecrübe Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Tecrübeleriniz',
                            text: 'Tecrübe güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Tecrübeleriniz',
                text: 'Tecrübe verileri getirilirken bir hata oluştu.'
            });
        }
    });
}
//WHistory Stop
//Education Start
function getEducationData() {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetEducation",
        success: function (data) {
            var card = '';
            $('#education-cards').empty();
            $.each(data, function (i, education) {
                card = '<div class="col-12 col-sm-6 col-md-4 d-flex align-items-stretch flex-column">' +
                    '<div class="card bg-light d-flex flex-fill">' +
                    '<div class="card-header text-muted border-bottom-0 text-center"><b>Okul Adı</b>:' + education.schoolName + '</div>' +
                    '<div class="card-body pt-0">' +
                    '<div class="row">' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Giriş Tarihi</b>: ' + education.startDate + '</p>' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Bitirme Tarihi</b>: ' + education.finishDate + '</p>' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Bölüm</b>: ' + education.educationBranch + '</p>' +
                    '</div>' +
                    '<div class="col-12">' +
                    '<p class="text-muted text-sm"><b>Okul Açıklaması</b>: ' + education.educationDescription + '</p>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="card-footer">' +
                    '<div class="text-right">' +
                    '<div class="btn-group">' +
                    '<button type="button" class="btn btn-sm btn-warning" onclick="editEducation(' + education.educationID + ')">' +
                    '<i class="fas fa-edit"></i> Düzenle' +
                    '</button>' +
                    '<button type="button" class="btn btn-sm btn-danger" onclick="deleteEducation(' + education.educationID + ')">' +
                    '<i class="fas fa-trash"></i> Sil' +
                    '</a>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>';
                $('#education-cards').append(card);
            });
        },
        error: function () {
            Swal.fire({
                icon: 'danger',
                title: 'Eğitiminiz',
                text: 'Bir Hata Oluştu Verileri Çekemiyoruz !'
            });
        }
    });
}

$('#addEducationButton').click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append('ResumeID', $('#ResumeID').val());
    formData.append('StartDate', $('#StartDateE').val());
    formData.append('FinishDate', $('#FinishDateE').val());
    formData.append('EducationBranch', $('#EducationBranch').val());
    formData.append('SchoolName', $('#SchoolName').val());
    formData.append('EducationDescription', $('#EducationDescription').val());

    $.ajax({
        type: "POST",
        url: "/ResumeSettings/AddEducation",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            $('#modal-addEducation').modal('hide');
            console.log(data);
            getEducationData();
            Swal.fire({
                icon: 'success',
                title: 'Eğitiminiz',
                text: 'Eğitim Başarıyla Eklendi'
            });
        },
        error: function (xhr, status, error) {
            Swal.fire({
                icon: 'danger',
                title: 'Eğitiminiz',
                text: 'Eğitim Hata Oluştu !'
            });
        }
    });
});

function deleteEducation(educationID) {
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
                url: '/ResumeSettings/DeleteEducation',
                data: { 'id': educationID },
                type: 'POST',
                success: function (data) {
                    if (data.success) {
                        Swal.fire(
                            'Silindi!',
                            'Eğitim başarıyla silindi.',
                            'success'
                        ).then(() => {
                            getEducationData();
                        });
                    } else {
                        Swal.fire(
                            'Hata!',
                            'Eğitim silinirken bir hata oluştu. 1',
                            'error'
                        );
                    }
                },
                error: function () {
                    Swal.fire(
                        'Hata!',
                        'Eğitim silinirken bir hata oluştu. 2',
                        'error'
                    );
                }
            });
        }
    });
}

function editEducation(educationID) {
    $.ajax({
        type: "GET",
        url: "/ResumeSettings/GetEducationById/" + educationID,
        success: function (data) {
            $('#StartDateU').val(data.startDate);
            $('#FinishDateU').val(data.finishDate);
            $('#EducationBranchU').val(data.educationBranch);
            $('#SchoolNameU').val(data.schoolName);
            $('#EducationDescriptionU').val(data.educationDescription);
            $('#EducationID').val(data.educationID);

            $('#modal-updateEducation').modal('show');

            $('#update-education-form').on('submit', function (e) {
                e.preventDefault();
                var formData = new FormData();
                formData.append('StartDate', $('#StartDateEU').val());
                formData.append('FinishDate', $('#FinishDateEU').val());
                formData.append('EducationBranch', $('#EducationBranchU').val());
                formData.append('SchoolName', $('#SchoolNameU').val());
                formData.append('EducationDescription', $('#EducationDescriptionU').val());
                formData.append('EducationID', $('#EducationID').val());

                $.ajax({
                    type: "POST",
                    url: "/ResumeSettings/UpdateEducation/",
                    data: formData,
                    processData: false,
                    contentType: false,
                    success: function () {
                        $('#modal-updateEducation').modal('hide');
                        getEducationData();
                        hobbieID = null;
                        formData = null;
                        Swal.fire({
                            icon: 'success',
                            title: 'Eğitiminiz',
                            text: 'Eğitim Başarıyla Güncellendi'
                        });
                    },
                    error: function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Eğitiminiz',
                            text: 'Eğitim güncelleme sırasında bir hata oluştu.'
                        });
                    }
                });
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Eğitiminiz',
                text: 'Eğitim verileri getirilirken bir hata oluştu.'
            });
        }
    });
}
//Education Stop
