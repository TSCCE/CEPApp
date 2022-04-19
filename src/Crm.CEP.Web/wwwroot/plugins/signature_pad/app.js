var wrapper = document.getElementById("signature-pad"),
    clearButton = wrapper.querySelector("[data-action=clear-signpad]"),
    saveButton = wrapper.querySelector("[data-action=save-signpad]"),
    closeButton = wrapper.querySelector("[data-action=close-signpad]"),
    canvas = wrapper.querySelector("canvas"),
    signaturePad;
var signPadOnSaveCallback = null;
var SIGNATURE_CHANGED = false;
// Adjust canvas coordinate space taking into account pixel ratio,
// to make it look crisp on mobile devices.
// This also causes canvas to be cleared.
function resizeCanvas() {
    // When zoomed out to less than 100%, for some very strange reason,
    // some browsers report devicePixelRatio as less than 1
    // and only part of the canvas is cleared then.
    var ratio =  Math.max(window.devicePixelRatio || 1, 1);
    canvas.width = canvas.offsetWidth * ratio;
    canvas.height = canvas.offsetHeight * ratio;
    canvas.getContext("2d").scale(ratio, ratio);
}

function SignaturePad_Reset() {
    SIGNATURE_CHANGED = false;
    signaturePad.clear();
}

window.onresize = resizeCanvas;
resizeCanvas();

signaturePad = new SignaturePad(canvas);

clearButton.addEventListener("click", function (event) {
    signaturePad.clear();
});

closeButton.addEventListener("click", function (event) {
    signaturePad.clear();
    $('#signature-pad').addClass('Hide-default');
});

saveButton.addEventListener("click", function (event) {
    if (signaturePad.isEmpty()) {
        alert("Please provide signature first.");
    } else {
        $('#signature-pad').addClass('Hide-default');
        if (signPadOnSaveCallback != null)
            signPadOnSaveCallback(signaturePad.toDataURL());

        SIGNATURE_CHANGED = true;
        
        //window.open(signaturePad.toDataURL());
    }
});
