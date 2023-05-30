

const previewimg = function (event) {
    var result = document.getElementById('previewImage');
    if (result) {
        result.src = URL.createObjectURL(event.target.files[0]);
    };

}