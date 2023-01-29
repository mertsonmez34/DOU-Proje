$(document).ready(function () {
    var buttonForTshirtAndJacket = document.getElementById("btnFMSForTshirtAndJacket");
    var hiddenType = document.getElementById("hiddenType").innerHTML;

    if (hiddenType == "T-Shirt" || hiddenType == "Ceket") {
        buttonForTshirtAndJacket.addEventListener("click", function () {
            var e = document.getElementById("sizeTypeForTshirtAndJacket");
            var text = e.options[e.selectedIndex].text;
            var height = parseInt(document.getElementById("heightForTshirtAndJacket").value);
            var weight = parseInt(document.getElementById("weightForTshirtAndJacket").value);
            var divided = height / 100;
            var bmi = weight / (divided * divided);
            if (text == "Tight") {

                if (bmi < 18.5) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = " The available size is: XS";
                }
                else if (bmi < 25) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: S";
                }
                else if (bmi < 30) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: M";
                }
                else if (bmi < 35) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: L";
                }
                else if (bmi <= 40) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: XL";
                }
                else {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "OVERSIZE";
                }
            }
            if (text == "Regular") {
                if (bmi < 18.5) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: S";
                }
                else if (bmi < 25) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: M";
                }
                else if (bmi < 30) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: L";
                }
                else if (bmi < 35) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: XL";
                }
                else if (bmi <= 40) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: XXL";
                }
                else {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "OVERSIZE";
                }
            }
            if (text == "Oversize") {
                if (bmi < 18.5) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: M";
                }
                else if (bmi < 25) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: L";
                }
                else if (bmi < 30) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: XL";
                }
                else if (bmi < 35) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: XXL";
                }
                else if (bmi <= 40) {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "The available size is: XXXL";
                }
                else {
                    document.getElementById("resultForTshirtAndJacket").innerHTML = "OVERSIZE";
                }
            }
        });
    }
    else if (hiddenType == "Elbise" || hiddenType == "Pantolon") {
        var buttonForClothesAndJeans = document.getElementById("btnFMSForClothesAndJeans");
        buttonForClothesAndJeans.addEventListener("click", function () {
            var e = document.getElementById("sizeTypeForClothesAndJeans");
            var text = e.options[e.selectedIndex].text;
            var height = parseInt(document.getElementById("heightForClothesAndJeans").value);
            var weight = parseInt(document.getElementById("weightForClothesAndJeans").value);
            var divided = height / 100;
            var bmi = weight / (divided * divided);
            if (text == "Tight") {

                if (bmi < 18.5) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = " The available size is: 28";
                }
                else if (bmi < 22) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 30";
                }
                else if (bmi < 25) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 32";
                }
                else if (bmi < 28) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 34";
                }
                else if (bmi < 30) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 36";
                }
                else if (bmi < 33) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 38";
                }
                else if (bmi < 37) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 40";
                }
                else if (bmi <= 40) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 42";
                }
                else {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "OVERSIZE";
                }
            }
            if (text == "Regular") {
                if (bmi < 18.5) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 30";
                }
                else if (bmi < 22) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 32";
                }
                else if (bmi < 25) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 34";
                }
                else if (bmi < 28) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 36";
                }
                else if (bmi < 30) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 38";
                }
                else if (bmi < 33) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 40";
                }
                else if (bmi < 37) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 42";
                }
                else if (bmi <= 40) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 44";
                }
                else {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "OVERSIZE";
                }
            }
            if (text == "Oversize") {
                if (bmi < 18.5) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 32";
                }
                else if (bmi < 22) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 34";
                }
                else if (bmi < 25) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 36";
                }
                else if (bmi < 28) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 38";
                }
                else if (bmi < 30) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 40";
                }
                else if (bmi < 33) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 42";
                }
                else if (bmi < 37) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 44";
                }
                else if (bmi <= 40) {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "The available size is: 46";
                }
                else {
                    document.getElementById("resultForClothesAndJeans").innerHTML = "OVERSIZE";
                }
            }
        });
    }
});