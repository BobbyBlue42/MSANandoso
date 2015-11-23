var Internet = (function () {
    return {
        getStudents: function (callback) {
            var xhttp = new XMLHttpRequest();

            //This gets triggered when the state of the xhttp object changes
            xhttp.onreadystatechange = function () {
                // 4 - repsonse is ready, 200 success code
                if (xhttp.readyState == 4 && xhttp.status == 200) {
                    loadedItems();
                }
            }

            // Build up our request and send it - true for async
            xhttp.open("GET", "http://localhost:12095/api/Items", true);
            xhttp.setRequestHeader("Content-type", "application/json");
            xhttp.send(null);

            // Parse and send the studentlist data back to index.js
            function loadedItems() {
                var itemsList = JSON.parse(xhttp.responseText);
                callback(itemsList);
                return itemsList;
            }
        }
    }
}

()

);