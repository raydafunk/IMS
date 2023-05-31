function PreventFormSubmittion(formId) {

    document.getElementById('${formId}').addEventListener("Keydown", function (event) {
        if (event.keyCode == 13) {

            console.log(formId, form)
            event.preventDefault();
            return false;             
        }
    });
}