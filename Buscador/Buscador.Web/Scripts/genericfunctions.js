function ChangeTab(tab) 
{
    document.getElementById("Tabsdiv").className = 'desplegadosContenedor ' + tab;

    switch (tab) {
        case 'fotos':
            if (document.getElementById(tab) != null) document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#especific') != null) $('#especific').attr('class', 'solapaDinamica solEspecif');
            if ($('#videos') != null) $('#videos').attr('class', 'solapaDinamica solVideos');
            //document.getElementById('trecientos60').className = document.getElementById('trecientos60').className.replace("active", " ");
            if ($('#review') != null) $('#review').attr('class', 'solapaDinamica solReview');
            break;
        case 'videos':
            if (document.getElementById(tab) != null)  document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#especific') != null) $('#especific').attr('class', 'solapaDinamica solEspecif');
            if ($('#fotos') != null) $('#fotos').attr('class', 'solapaDinamica solFotos');
            //document.getElementById('trecientos60').className = document.getElementById('trecientos60').className.replace("active", " ");
            if ($('#review') != null) $('#review').attr('class', 'solapaDinamica solReview');
            break;
        case 'especific':
            if (document.getElementById(tab) != null) document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#fotos') != null) $('#fotos').attr('class', 'solapaDinamica solFotos');
            if ($('#videos') != null) $('#videos').attr('class', 'solapaDinamica solVideos');
            //document.getElementById('trecientos60').className = document.getElementById('trecientos60').className.replace("active", " ");
            if ($('#review') != null) $('#review').attr('class', 'solapaDinamica solReview');
            activeSubTab();
            break;
//        case 'trecientos60':
//            document.getElementById(tab).className = document.getElementById(tab).className + ' active';
//            document.getElementById('fotos').className = document.getElementById('fotos').className.replace("active", " ");
//            document.getElementById('videos').className = document.getElementById('videos').className.replace("active", " ");
//            document.getElementById('especific').className = document.getElementById('especific').className.replace("active", " ");
//            document.getElementById('review').className = document.getElementById('review').className.replace("active", " ");
//            break;
        case 'review':
            if (document.getElementById(tab) != null)  document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#fotos') != null) $('#fotos').attr('class', 'solapaDinamica solFotos');
            if ($('#videos') != null) $('#videos').attr('class', 'solapaDinamica solVideos');
            //document.getElementById('trecientos60').className = document.getElementById('trecientos60').className.replace("active", " ");
            if ($('#especific') != null) $('#especific').attr('class', 'solapaDinamica solEspecif');
            break;
    }
}

function activeSubTab() {
    if (document.getElementById('equip') != null)
        ChangeSubTab('equip');
    else
        if (document.getElementById('ficha') != null)
            ChangeSubTab('ficha');
        else
            if (document.getElementById('colores') != null)
                ChangeSubTab('colores');
}

function ChangeSubTab(tab)
{
    document.getElementById("Subtabsdiv").className = 'Desplegado EspecificacionesCont ' + tab;

    switch (tab) 
    {
        case 'equip':
            if (document.getElementById(tab) != null)  document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#ficha') != null) $('#ficha').attr('class', 'center');
            if ($('#colores') != null) $('#colores').attr('class', 'last'); 
            break;
        case 'ficha':
            if (document.getElementById(tab) != null) document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#equip') != null)  $('#equip').attr('class','first');
            if ($('#colores') != null) $('#colores').attr('class', 'last'); 
            break;
        case 'colores':
            if (document.getElementById(tab) != null)  document.getElementById(tab).className = document.getElementById(tab).className + ' active';
            if ($('#equip') != null) $('#equip').attr('class', 'first');
            if ($('#ficha') != null) $('#ficha').attr('class', 'center');
            break;
    }
}

function OpenSpecs(divId) 
{
    if (document.getElementById(divId).className.indexOf('open') != -1)
        if (document.getElementById(divId).className.indexOf('last') != -1)
            document.getElementById(divId).className = 'CONFORT last';
        else
            document.getElementById(divId).className = 'CONFORT';
    else
        document.getElementById(divId).className = document.getElementById(divId).className + ' open';
}


