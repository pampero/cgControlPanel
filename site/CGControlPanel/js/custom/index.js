jQuery(document).ready(function () {

    ///// TRANSFORM CHECKBOX /////							
    jQuery('input:checkbox').uniform();

    ///// LOGIN FORM SUBMIT /////
    jQuery('#login').submit(function () {

        if (jQuery('#username').val() == '' && jQuery('#password').val() == '') {
            jQuery('.nousername').fadeIn();
            jQuery('.nopassword').hide();
            return false;
        }
        if (jQuery('#username').val() != '' && jQuery('#password').val() == '') {
            jQuery('.nousername').hide();
            jQuery('.nopassword').fadeIn();
            return false; ;
        }
    });

    ///// ADD PLACEHOLDER /////
    jQuery('#username').attr('placeholder', 'Usuario');
    jQuery('#password').attr('placeholder', 'Clave');
});
