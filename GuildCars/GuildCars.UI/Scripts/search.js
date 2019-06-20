$(document).ready(function () {
    var MakeId;
    $('#MakeId').on("change", function () {
        MakeId = $('#MakeId').val();
        GetModels(MakeId);
    });
});

function GetModels(makeId) {
    dropdown = $('#ModelId');
    dropdown.empty();

    var urlString = '?MakeId=' + encodeURI(makeId);
    urlString = 'http://localhost:60718/api/models' + urlString;
    $.ajax({
        type: 'GET',
        url: urlString,
        success: function (data, status) {
            $.each(data, function (key, entry) {
                dropdown.append($('<option></option>').attr('value', entry.ModelId).text(entry.Description));
            });
        },
        error: function () {
            //alert('FAILURE!');
            $('#errors').text("Failed to retrieve Models. Contact I.T");
            $('#errors').show();
        }
    });
}

//Format two two deicmal places
function FormatCurrency(amount) {
    var i = parseFloat(amount);
    if (isNaN(i)) { i = 0.00; }
    var minus = '';
    if (i < 0) { minus = '-'; }
    i = Math.abs(i);
    i = parseInt((i + .005) * 100);
    i = i / 100;
    s = new String(i);
    if (s.indexOf('.') < 0) { s += '.00'; }
    if (s.indexOf('.') == (s.length - 2)) { s += '0'; }
    s = minus + s;
    return s;
}

//Format currency with commas
function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function GetSalesReport() {
    var fromDate = $('#fromDate').val()
    var toDate = $('#toDate').val();
    var userId = $('#userId').val();
    //Encode URL
    var urlString = '?fromDate=' + encodeURI(fromDate) + '&toDate=' + encodeURI(toDate) + '&userId=' + encodeURI(userId);
    urlString = 'http://localhost:60718/api/report/sales' + urlString;
    var searchlistcontentRows = $('#search-list-contentRows');
    searchlistcontentRows.empty();
    $.ajax({
        type: 'GET',
        url: urlString,
        success: function (data, status) {
            $.each(data, function (index, salesRpt) {
                var user = salesRpt.User;
                var totalSales = '$' + numberWithCommas(salesRpt.TotalSales);
                var totalVehicles = salesRpt.TotalVehicles;
                var row = '';
                row = '<tr><td>'
                row += user + '</td><td>'
                row += totalSales +  '</td><td>'
                row += totalVehicles + '</td></tr>'
                searchlistcontentRows.append(row);
            });
        },
        error: function () {
           // alert('FAILURE!');
            $('#errors').text("Failed to retrieve Sales Report. Contact I.T");
            $('#errors').show();
        }
    });
}
function searchInventory() {

    var mnYear = $('#mnYear').val()
    var mxYear = $('#mxYear').val();
    var mnPrice = $('#mnPrice').val();
    var mxPrice = $('#mxPrice').val();
    var searchTerm = $('#SearchTerm').val();
    var searchMode = $('#SearchMode').val();
    var buttonSelector = searchMode;

    //SQL stored proc expects these values for empty/null search term. They are set to null in stored proc if set.
    if (mnYear == '') {
        mnYear = 0;
    }
    if (mxYear == '') {
        mxYear = 0;
    }
    if (mnPrice == '') {
        mnPrice = 0;
    }
    if (mxPrice == '') {
        mxPrice = 0;
    }
    if (searchTerm == '') {
        searchTerm = '-1';
    }
    if (searchMode == "Sales" || searchMode == "Admin") {
        searchMode = '-1'
    }
    //Encode URL
    var urlString = '?minYear=' + encodeURI(mnYear) + '&maxYear=' + encodeURI(mxYear) + '&minPrice=' + encodeURI(mnPrice) + '&maxPrice=' + encodeURI(mxPrice) + '&searchTerm=' + encodeURI(searchTerm) + '&condition=' + encodeURI(searchMode);
    urlString = 'http://localhost:60718/api/inventory' + urlString;
    var searchlistcontentRows = $('#search-list-contentRows');
    searchlistcontentRows.empty();
    $.ajax({
        type: 'GET',
        url: urlString,
          success: function (data, status) {
            $.each(data, function (index, vehicleList) {
                var vehicleId = vehicleList.VehicleId;
                var year = vehicleList.Year;
                var vin = vehicleList.VIN;
                var transmissionType = vehicleList.TransmissionType;
                var BodyStyle = vehicleList.BodyStyle;
                var InteriorColor = vehicleList.InteriorColor;
                var ExteriorColor = vehicleList.ExteriorColor;
                var MSRP = '$' + numberWithCommas(vehicleList.MSRP);
                var Mileage = vehicleList.Mileage;
                var ImageFileName = vehicleList.ImageFileName;
                var SalePrice = '$' + numberWithCommas(vehicleList.SalePrice);
                var MakeDescription = vehicleList.MakeDescription;
                var ModelDescription = vehicleList.ModelDescription;
                var ImageFileName = vehicleList.ImageFileName;
                var row ='';
                row += '<div class="col-md-12 table-bordered" style="margin-top:10px; width:100%;">';
                row += '<div class="col-md-3"  style="padding-bottom: 15px; padding-top:15px">';
                row += '<label> Year:</label > ' + ' ' + year + ' ' + MakeDescription + ' ' + ModelDescription;
                row += '<br><img src="/Images/'
                row += ImageFileName
                row += '" />'
                row += '</div>';
                row += '<div class="col-md-3" style="padding-bottom: 15px; padding-top:15px">';
                row += '<label>Body Style:</Label>';
                row += ' ' + BodyStyle + '<br>';
                row += '<label>Trans:</label>';
                row += ' ' + transmissionType + '<br>';
                row += '<label>Color:</label>';
                row += ' ' + ExteriorColor;
                row += '<br></div>';
                row += '<div class="col-md-3"  style="padding-bottom: 15px; padding-top:15px">';
                row += '<label>Interior:</Label>';
                row += ' ' + InteriorColor + '<br>';
                row += '<label>Mileage:</label>';
                row += ' ' + Mileage + '<br>';
                row += '<label>VIN:</label>';
                row += ' ' + vin;
                row += '</div>';
                row += '<div class="col-md-3 text-right" style="padding-bottom: 15px; padding-top:15px">';
                row += '<label>Sale Price:</Label>';
                row += ' ' + SalePrice + '<br>';
                row += '<label>MSRP:</label>';
                row += ' ' + MSRP + '<br>';
                //Set the correct button and action for the search page
                if (buttonSelector != "Sales" && buttonSelector !="Admin") {
                    row += '<a class="btn btn-primary" href = "/Inventory/Detail?id=' + vehicleId + '">Details</a>';
                } else if (buttonSelector == "Sales") {
                    row += '<a class="btn btn-primary" href = "/Sales/Purchase?id=' + vehicleId + '">Purchase</a>';
                } else {
                    row += '<a class="btn btn-primary" href = "/Admin/EditVehicle?id=' + vehicleId + '">Edit</a>';
                }
                row += '</div>';
                row += '</div >';

                searchlistcontentRows.append(row);
            });
        },
        error: function () {
            //alert('FAILURE!');
            $('#errors').text("Failed to retrieve Inventory. Contact I.T");
            $('#errors').show();
        }
    });
}
