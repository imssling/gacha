function previewImage(file) {
    var allowType = "image.*";
    var file = file.files[0];
    if (file.type.match(allowType)) {
        //預覽圖片
        var reader = new FileReader();
        reader.onload = function (e) {
            //檔案讀取完成
            $('#machinePictureName').prev().attr("src", e.target.result);
            $('#machinePictureName').prev().attr("title", file.name);
        }
        //檔案讀取
        reader.readAsDataURL(file)
        $('.btn').prop('disabled', false);
    }
    else {
        alert("不支援的檔案上傳類型");
        $('.btn').prop('disabled', true);
    }
}