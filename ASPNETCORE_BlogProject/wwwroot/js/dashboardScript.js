
$(document).ready(function () {
    var totalUserCountsUrl = $("#TotalUserCounts").data("url");
    $.ajax({
        type: "GET",
        url: totalUserCountsUrl,
        dataType: "json",
        success: function (data) {
            $("h3#totalUserCount").append(data);
        },
        error: function () {
            toastr.error("Makale Analizleri yüklenirken hata oluştu", "Hata");
        }
    });
});