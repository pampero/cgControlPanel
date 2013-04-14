//Para que ingrese solamente numeros
function isNumberKey(evt) {
    if (evt.which <= 31)
        return true;

    var charCode = (evt.which) ? evt.which : event.keyCode
    //0-9 => 48-57
    if (charCode < 48 || charCode > 57)
        return false;

    return true;
}

//Para que ingrese letras
function isLettersUpperKey(evt) {
    if (evt.which <= 31)
        return true;

    var charCode = (evt.which) ? evt.which : event.keyCode

    //a-z => 97-122
    //A-Z => 65-90
    if ((charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90))
        return false;

    return true;
}

//Para que ingrese letras y espacios
function isLettersUpperKeyAndSpaces(evt) {
    if (evt.which <= 31)
        return true;

    var charCode = (evt.which) ? evt.which : event.keyCode

    //space bar => 32
    //backspace => 8
    if ((charCode == 32) || (charCode == 8)) 
        return true;
    
    //a-z => 97-122
    //A-Z => 65-90
    if ((charCode < 97 || charCode > 122) && (charCode < 65 || charCode > 90))
         return false;

    return true;
}

//Para que ingrese letras, numeros y espacios
function isLetterNumberSpaces(evt) 
{
    if (isNumberKey(evt) || isLettersUpperKeyAndSpaces(evt))
        return true;
    else
        return false;
}

//Para  ñ, acentos
function isAccentsAndCharecters(evt) {
    if (charCode < 190 || charCode > 242)
        return false;
    else
        return true;
}

//Para que ingrese $ y ?, coma , punto,
function isSpecialCharacters(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode == 36 || charCode == 37 || charCode == 63 || charCode == 44 || charCode == 46)
        return true
    return false;
}

//Para que ingrese letras, numeros, espacios, $, ? y limitar cantidad de caracteres
function isLetterNumberSpacesAndSpecialCharacters(evt, Object, MaxLen) {
    if ((isNumberKey(evt) || isLettersUpperKeyAndSpaces(evt) || isSpecialCharacters(evt) || isAccentsAndCharecters(evt)) && imposeMaxLength(Object, MaxLen))
        return true;
    else
        return false;
}

//Para que ingrese Letras, numeros, espacios, acentos, ñ
function isLetterNumberSapacesAndOthers(evt, Object, MaxLen) {
    if ((isNumberKey(evt) || isLettersUpperKeyAndSpaces(evt) || isSpecialCharacters(evt) || isOtherCharacters(evt)) && imposeMaxLength(Object, MaxLen))
        return true;
    else
        return false;
}

//Para que ingrese ñ, acentos y otros
function isOtherCharacters(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode >= 192 && charCode <= 255) 
        return true;
    return false;
}

//Validacion de mail
function isValidEmail(email) {
    var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    return filter.test(email);
}

//pasar a mayusculas
function ToUpper(evt) {
    // So that things work both on FF and IE
    var charCode = String.fromCharCode(evt.which || evt.keyCode);

    // Is it a lowercase character?
    if (/[a-z]/.test(charCode)) {
        // convert to uppercase version
        if (evt.which) {
            evt.which = charCode.toUpperCase();
        }
        else {
            evt.keyCode = charCode.toUpperCase();
        }
    }

    return true;
}

//Limitar la cantidad de caracteres
function imposeMaxLength(Object, MaxLen) {
    return (Object.value.length + 1 <= MaxLen);
}


//Para mostrar solamente un error
//function showValidateComplexError(divName, fields1, fields2) {

//    var cssField1 = $('#' + fields1 + '_validationMessage').attr("class");
//  //  alert($('#' + fields1 + '_validationMessage').attr("class"));
//    if (cssField1 != null)
//    {  
//        var cssField2 = $('#' + fields2 + '_validationMessage').attr("class");
//        if (cssField1.indexOf('field-validation-error') > -1) {
//            $('#' + divName).html($('#' + fields1 + '_validationMessage_div').html());
//            $('#' + divName).addClass('contError');
//        }
//        else if (cssField2.indexOf('field-validation-error') > -1) {
//            $('#' + divName).html($('#' + fields2 + '_validationMessage_div').html());
//            $('#' + divName).addClass('contError');
//        }
//        else {
//            $('#' + divName).html("");
//            $('#' + divName).removeClass('contError');
//        }
//    }
//}

//VALIDACION DE AÑO DE AUTOS USADOS
//Sys.Mvc.ValidatorRegistry.validators.yearUserCarVal = function (rule) {
//    // we return the function that actually does the validation 
//    return function (value, context) {
//        if (isNaN(value)) {
//            return false;
//        }

//        //Valida si el año es correcto
//        var dateNow = new Date();
//        var dateyear = dateNow.getFullYear();

//        if (value < dateyear) {
//            //A partir de 1910
//            return value >= 1910;
//        }
//        else if (value > dateyear) {
//            //No puede ser año superior al acutal
//            return false;
//        }
//        //si llego aca, es porque es el mismo año, verificar que sea mayor o igual a Marzo
//        //Javascript 0=Enero
//        var month = dateNow.getMonth();
//        return (month >= 2);
//    };
//};


//VALIDACION DE CHECK (Ej: Acepto condiciones)
//Sys.Mvc.ValidatorRegistry.validators.requiredToBeTrueVal = function (rule) {
//    // we return the function that actually does the validation 
//    return function (value, context) {
//        return context.fieldContext.elements[0].checked === true;
//    };
//};

//VALIDACION DE CAMPOS IGUALES(Ej: Confirmar Email)
//Sys.Mvc.ValidatorRegistry.validators.mustMatch = function (rule) {
//    var propertyIdToMatch = rule.ValidationParameters.PropertyToMatch;
//    var message = rule.ErrorMessage;

//    return function (value, context) {
//        var thisField = context.fieldContext.elements[0];
//        var propertyToMatch = '';

//        var array = thisField.id.split('_');
//        if (array.length > 1) {
//            for (var iPos = 0; iPos < array.length - 1; iPos++) {
//                propertyToMatch += array[iPos] + "_";
//            }
//        }

//        propertyToMatch += propertyIdToMatch;

//        var otherField = $get(propertyToMatch, thisField.form);

//        if (otherField.value != value) {
//            return false;
//        }

//        return true;
//    };
//}; 

//VALIDACION DE PATENTE
//Sys.Mvc.ValidatorRegistry.validators.phomeNumberVal = function (rule) {
//    // we return the function that actually does the validation 
//    return function (value, context) {
//        return true;
//    };
//};

//VALIDACION DE PATENTE
//Sys.Mvc.ValidatorRegistry.validators.plateusedcarval = function (rule) {
//    // we return the function that actually does the validation 
//    return function (value, context) {
//        var letterPropertyControl = $("#Plate.PlateLetters");
//        if (letterPropertyControl == null) {
//            return false;
//        }
//        //var letterPropertyValue = letterPropertyControl[0].value;

//        var numberPropertyControl = $("#Plate.PlateNumbers");
//        if (numberPropertyControl == null) {
//            return false;
//        }

//        //var numberPropertyValue = numberPropertyControl[0].value;
//        //return numberPropertyValue == letterPropertyValue;
//        return true;
//    };
//};
////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

var showPopupError = false;
var urlpopupError = '';
var errorfound = false;

//Verifica los span de validacion del cliente, si quedó algunos inválidos y no se muestra
//function VerifyAttrValidClient() {
//    //Recorre todo los span de validacion que no esten válidos
//    $.each($('[AttrValidClient=true].field-validation-error'), function () {
//        var currentId = $(this).attr('id');
//        var currentClass = $(this).attr('class');
//        if (currentClass != "") {
//            var divId = '#' + currentId + '_div';
//            if (currentClass == 'field-validation-error') {
//                $(divId).removeClass("field-validation-valid");
//                $(divId).addClass("field-validation-error");
//                $(divId).css('display', '');
//                
//            }
//            else {
//                $(divId).removeClass("field-validation-error");
//                $(divId).addClass("field-validation-valid");
//                $(divId).css('display', 'none');
//            }
//        }
//    });

//}

//jQuery(function ($) {
//    RegisterAttrValidClientClassChange();
//});

//function RegisterAttrValidClientClassChange() {
//    errorfound = false;
//    $('[AttrValidClient=true]').watch('class', function () {

//        var currentId = $(this).attr('id');
//        var currentClass = $(this).attr('class');
//        if (currentClass != "") {
//            var divId = '#' + currentId + '_div';
//            if (currentClass == 'field-validation-error') {
//                $(divId).removeClass("field-validation-valid");
//                $(divId).addClass("field-validation-error");
//                $(divId).css('display', '');
//                window.scrollTo(250, 250);
//                if (!errorfound) {
//                        if (showPopupError && urlpopupError != '') {
//                        $.fn.colorbox({ href: urlpopupError });
//                    }
//                    errorfound = true;
//                }
//                showValidateComplexError('PlateValidShowError', 'PlateLetters', 'PlateNumbers');
//                showValidateComplexError('PriceValidShowError', 'CustomCurrencyId', 'Price');

//            }
//            else {
//                $(divId).removeClass("field-validation-error");
//                $(divId).addClass("field-validation-valid");
//                $(divId).css('display', 'none');
//            }
//        }
//    });
//}

//
// Watch Plugin
//
//$.fn.watch = function (props, callback, timeout) {
//    if (!timeout)
//        timeout = 1;
//    return this.each(function () {
//        var el = $(this),
//			func = function () { __check.call(this, el) },
//			data = { props: props.split(","),
//			    func: callback,
//			    vals: []
//			};
//        $.each(data.props, function (i) {
//            data.vals[i] = el.css(data.props[i]);
//            //data.vals[i] = el.attr(data.props[i]);
//            //alert(data.vals[i]);
//        });
//        el.data(data);
//        if (typeof (this.onpropertychange) == "object") { //IE
//            el.bind("propertychange", callback);
//        } else if ($.browser.mozilla) { //Firefox 
//            el.bind("DOMAttrModified", callback);
//        } else if ($.browser.opera) { //Opera
//            el.bind("DOMAttrModified", callback);
//        } else {
//            setInterval(func, timeout);
//        }
//    });

//    function __check(el) {
//        var data = el.data(),
//			changed = false,
//			temp = "";
//        for (var i = 0; i < data.props.length; i++) {
//            temp = el.css(data.props[i]);
//            if (data.vals[i] != temp) {
//                data.vals[i] = temp;
//                changed = true;
//                break;
//            }
//        }
//        if (changed && data.func) {
//            data.func.call(el, data);
//        }
//    }
//}