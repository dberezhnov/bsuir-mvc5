resultDiv = document.getElementById("result");

document.getElementById("picture").addEventListener("change", function (e) {
    if (e.target.files.length == 0) return;
    var file = e.target.files[0];
    if (!file.type.startsWith("image")) {
        resultDiv.classList.remove("closing");
        resultDiv.innerText = "Это не картинка";
        resultDiv.style.backgroundColor = "red";
        window.setTimeout(function () {
            resultDiv.classList.add("closing");
        }, 1000);
        return;
    }

    var formData = new FormData();
    formData.append(file.name, file);
    var ajax = new XMLHttpRequest();
    ajax.open("POST", "/Home/SendPicture");
    ajax.onreadystatechange = function () {
        if (ajax.readyState != 4) return;
        resultDiv.classList.remove("closing");
        if (ajax.status == 200) {
            resultDiv.innerText = "Картинка успешно принята";
            resultDiv.style.backgroundColor = "lime";
        } else {
            resultDiv.innerText = "Ошибка при приеме картинки";
            resultDiv.style.backgroundColor = "red";
        }
        window.setTimeout(function () {
            resultDiv.classList.add("closing");
        }, 1000);
    };
    ajax.send(formData);
});