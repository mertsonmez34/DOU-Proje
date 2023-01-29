
$(document).ready(function () {
    var option = document.querySelectorAll("#option");
    var id = parseInt(document.getElementById("prodId").innerHTML);

    $('#addToCard').click(function () {
        

        var selectedOption;
        for (const radioOption of option) {
            if (radioOption.checked) {
                selectedOption = radioOption.value;
                break;
            }
        }

        var soapMessage = `<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope" xmlns:tem="http://tempuri.org/">
               <soap:Header/>
               <soap:Body>
                  <tem:UpdateData>
                     <tem:id>`+ id + `</tem:id>
                     <!--Optional:-->
                     <tem:option>`+ selectedOption + `</tem:option>
                  </tem:UpdateData>
               </soap:Body>
            </soap:Envelope>`;


        var xmlhttp = new XMLHttpRequest();
        xmlhttp.open('POST', 'https://localhost:44386/Service/UpdateOption.asmx', true);

        // build SOAP request



        // Send the POST request
        xmlhttp.setRequestHeader('Content-Type', 'text/xml');
        xmlhttp.send(soapMessage);
            // send request
            // ...

    });

});

