function completeSubmit(itemname) {
    var name = document.getElementById("nameBox");
    var score = document.getElementById("scoreBox");
    var review = document.getElementById("reviewBox");
}

function setupDropDown(items) {
    dropdown = document.getElementById("dropDown");
    for (i = 0; i < items.length; i++) {
        var option = document.createElement("option");

        option.value = items[i].name;
        option.textContent = items[i].name;

        dropdown.appendChild(option);
    }
}