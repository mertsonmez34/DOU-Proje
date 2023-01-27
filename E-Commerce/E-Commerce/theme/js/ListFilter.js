var ValArrayOfType = [];
var ValArrayOfBrand = [];
var cards = [];
const unique = (value, index, self) => {
    return self.indexOf(value) === index
}
const prices = document.querySelectorAll("#priceOfProduct");
const minPrice = document.querySelectorAll('input[name="min"]');
const maxPrice = document.querySelectorAll('input[name="max"]');
const card = document.querySelectorAll("#listCards");
const type = document.querySelectorAll('input[name="type"]');
const brand = document.querySelectorAll('input[name="brand"]');
const hiddenType = document.querySelectorAll("#hiddenType");
const brandOfCards = document.querySelectorAll("#brandOfCard");
const hiddenBrand = document.querySelectorAll("#hiddenBrand");
const typeOfCards = document.querySelectorAll("#typeOfCard");
const typeBr = document.querySelectorAll("#typeBr");
const brandBr = document.querySelectorAll("#brandBr");
const counter = document.getElementById("counter");

///////////////////////////////////////////////////////// Type Seçimindeki Label kısmının çoklamasını önler
for (j = 0; j < hiddenType.length; j++) {
    ValArrayOfType.push(hiddenType[j].innerHTML);
}
var uniqueType = ValArrayOfType.filter(unique);
for (i = 0; i < uniqueType.length; i++) {
    hiddenType[i].innerHTML = uniqueType[i];
}
for (j = 0 + uniqueType.length; j < hiddenType.length; j++) {
    hiddenType[j].remove();
    typeBr[j].remove();

}
//////////////////////////////////////////////////// Type Seçimindeki Radio Button kısmının çoklamasını önler
var uniqueTypeOfInput = ValArrayOfType.filter(unique);
for (i = 0; i < type.length; i++) {
    type[i].defaultValue = uniqueTypeOfInput[i];
}
for (j = 0 + uniqueTypeOfInput.length; j < type.length; j++) {
    type[j].remove();
}
///////////////////////////////////////////////// Brand Seçimindeki Label kısmının çoklamasını önler
for (j = 0; j < hiddenBrand.length; j++) {
    ValArrayOfBrand.push(hiddenBrand[j].innerHTML);
}
var uniqueBrand = ValArrayOfBrand.filter(unique);
for (i = 0; i < uniqueBrand.length; i++) {
    hiddenBrand[i].innerHTML = uniqueBrand[i];

    for (j = 0 + uniqueBrand.length; j < hiddenBrand.length; j++) {
        hiddenBrand[j].remove();
        brandBr[j].remove();
    }
}
///////////////////////////////////////////////// Brand Seçimindeki Radio Button kısmının çoklamasını önler
var uniqueBrandOfInput = ValArrayOfBrand.filter(unique);
for (i = 0; i < type.length; i++) {
    brand[i].defaultValue = uniqueBrandOfInput[i];
}
for (j = 0 + uniqueBrandOfInput.length; j < brand.length; j++) {
    brand[j].remove();
}
function typeFunction() {
    let selectedType;
    let selectedBrand;
    ///////////////////////////////////////////////// Type Seçimini filtreleyen koddur
    for (const radioType of type) {
        if (radioType.checked) {
            selectedType = radioType.value;
            for (i = 0; i < typeOfCards.length; i++) {
                if (selectedType != typeOfCards[i].textContent) {
                    card[i].remove();
                }
                else {
                    continue;
                }
            }
        }
    }
    //////////////////////////////////////////////////////Brand Seçimini filtreleyen koddur
    for (const radioBrand of brand) {
        if (radioBrand.checked) {
            selectedBrand = radioBrand.value;
            for (i = 0; i < brandOfCards.length; i++) {
                if (selectedBrand != (brandOfCards[i].textContent)) {
                    card[i].remove();
                }
            }
        }
    }
    //////////////////////////////////////////////////// Fiyatı Filtreler
    for (i = 0; i < prices.length; i++) {
        if (parseInt(minPrice[0].value) <= parseInt(prices[i].innerHTML) && parseInt(prices[i].innerHTML) <= parseInt(maxPrice[0].value)) {

        }
        else {
            card[i].remove();
        }

    }

};
function CalculateNumberOfProduct() {
    counter.innerHTML = +" " + document.querySelectorAll("#listCards").length + " product found";
};
function reloadPage() {
    location.reload();
};
