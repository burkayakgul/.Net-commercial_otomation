$(document).ready(function () { 
    let iter = 0;
    let inputFile = $(`#input-file-${iter}`);
    const label = $("#file-label");
    const formDiv = $(".form-group div ul");
    $("#ulElement").sortable();
    inputFile.change(function (event) {
        var url = URL.createObjectURL(event.target.files[0]);
        formDiv.append(`
            <li style="display:inline-block !important;" class="list-group-item ui-state-default">
                <input hidden id="input-file-${iter + 1}" name="resim-${iter + 1}"  value="resim-${iter+1}" type="file" >
                <img src="${url}" style="height:200px;width:200px;" />
                <i style="font-size:25px;cursor:pointer;" id="delete-${iter}" data-input="input-file-${iter}" onClick="deleteItem(this.id)" class="bi bi-x deleteButton"></i>
            </li>
        `);
        iter = iter + 1;
    });
    
    deleteItem =  function (id) {
        console.log();
        $("#"+id).parent().remove();
    }
    $("#image-ul").sortable();
});