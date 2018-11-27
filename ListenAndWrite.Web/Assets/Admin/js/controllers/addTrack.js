
var track = {
    init: function () {
        track.initGrid();

    },
    initGrid: function () {
        dataSource = new kendo.data.DataSource({
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true,
            transport: {
                read: {
                    url: "@Url.Action("GetTracks", "Admin",new { audioId = Model.Id })",
                    contentType: "application/json",
                    type: "POST"
                },
                update: {
                    url: "/Admin/UpdateTrack",
                    contentType: "application/json",
                    type: "POST"
                },
                destroy: {
                    url: "/Admin/DeleteTrack",
                    contentType: "application/json",
                    type: "POST"
                },
                create: {
                    url: "/Admin/CreateTrack",
                    contentType: "application/json",
                    type: "POST"
                },
                parameterMap: function (data, operation) {
                    if (operation != "read") {
                        // post the products so the ASP.NET DefaultModelBinder will understand them:
                        // products[0].Name="name"
                        // products[0].ProductID =1
                        // products[1].Name="name"
                        // products[1].ProductID =1
                        //var result = {};
                        //for (var i = 0; i < data.models.length; i++) {
                        //    var product = data.models[i];
                        //    for (var member in product) {
                        //        result["products[" + i + "]." + member] = product[member];
                        //    }
                        //}
                        //return result;
                        return JSON.stringify({ tracks: data.models, audioId: $('#audioId').val() })
                    } else {
                        return JSON.stringify(data)
                    }
                }
            },
            batch: true,
            pageSize: 20,
            schema: {
                data: "Data",
                total: "Total",
                model: {
                    id: "Id",
                    fields: {
                        Id: { editable: false, nullable: true },
                        Order: { type: "number", validation: { min: 1, required: true } },
                        Answer: { type: "string", validation: { required: true } },
                        TimeStart: { type: "number", validation: { min: 0, required: true } },
                        Duration: { type: "number", validation: { min: 0, required: true } }
                    }
                }
            }
        });
        $("#grid").kendoGrid({
            requestEnd: function (e) {
                if ((e.type === "update" || e.type === "destroy") && e.response) {
                    $("#grid").data('kendoGrid').dataSource.read();

                }
            },
            dataSource: dataSource,
            editable: true, // enable editing
            pageable: true,
            sortable: true,
            filterable: true,
            height: 550,
            toolbar: ["create"],
            columns: [
                "Order",
                { field: "Answer", title: "Answer", width: "55%" },
                { field: "TimeStart", title: "TimeStart", width: "10%" },
                { field: "Duration", title: "Duration", width: "10%" },
                { command: ["edit", "destroy"], title: "Action", width: "15%" }],
            editable: "inline"
        });
    },

}
track.init();
