

$(document).ready(function () {
    document.getElementById('pro-image').addEventListener('change', readImage, false);

    $(".preview-images-zone").sortable();

    $(document).on('click', '.image-cancel', function () {
        let no = $(this).data('no');
        $(".preview-image.preview-show-" + no).remove();
    });
});

let index = 0;
let num = 4;
function readImage() {
    if (window.File && window.FileList && window.FileReader) {
        var files = event.target.files; 
        var output = $(".preview-images-zone");
        var imagesIn = $(".Images");

        for (let i = 0; i < files.length; i++) {
            var file = files[i];
            if (!file.type.match('image')) continue;

            var picReader = new FileReader();

            picReader.addEventListener('load', function (event) {
                var picFile = event.target;

                // adding images to the car form
                var imgHtml = `<input id="images${index}" type="text" name="Images[${index}][ImageUrl]" style="display: none;" class="form-control" value="${picFile.result}">`;
                imagesIn.append(imgHtml);
                index++;

                var html = '<div class="preview-image preview-show-' + num + '" style="max-height: 100px; max-width: 100px;">' +
                    '<div class="image-cancel" data-no="' + num + '">x</div>' +
                    '<div class="image-zone"><img id="pro-img-' + num + '" src="' + picFile.result + '"></div>' +
                    '</div>';
                console.log(picFile.result)
                output.append(html);
                num = num + 1;
            });

            picReader.readAsDataURL(file);
        }
        $("#pro-image").val('');
    } else {
        console.log('Browser not support');
    }
}