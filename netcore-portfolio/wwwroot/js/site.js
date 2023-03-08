////$(document).ready(function () {
////    $.ajax({
////        type: 'GET',
////        url: '/ResumeSettings/GetResume/',
////        success: function (resume) {
////            $('#title').val(resume.title);
////            $('#phone').val(resume.phone);
////            $('#resumeimage').attr('src', resume.resumeImage);

////        },
////        error: function () {
////            alert('Veriler yüklenirken hata oluştu.');
////        }
////    });
////});

function getResumeData() {
    $.ajax({
        type: 'GET',
        url: '/ResumeSettings/GetResume/',
        success: function (resume) {
            $('#title').val(resume.title);
            $('#phone').val(resume.phone);
            $('#resumeimage').attr('src', resume.resumeImage);

        },
        error: function () {
            alert('Veriler yüklenirken hata oluştu.');
        }
    });
}