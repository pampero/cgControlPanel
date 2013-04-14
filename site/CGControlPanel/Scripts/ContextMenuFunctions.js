
// Grilla Relacionados: Ejecutar y Agendar.
// Grillas Diarios: Ejecutar para Manuales.
// Resto de las Grillas: Ejecutar, Agendar, Relacionados.
function HideContextMenu(gridName) {

    // Si es grilla de Relacionados no mostrar el menú Relacionados.
    if (currentGridSelected.name == "MainContent_grdRelatedJobs")
        pmRowMenu.GetItem(6).SetVisible(false);
    else {
        pmRowMenu.GetItem(6).SetVisible(true);
    }

    // Si no es una fecha habilitada para realizar operaciones solo muestra el menú Relacionados.
    if (isEnabledDateSelected)
        switch (gridName) {
            case "DailyJobsAutomático":
                break;
            case "DailyJobsManual":
                    pmRowMenu.GetItem(2).SetVisible(true);
                break;
            case "OtherJobsAutomático":
                pmRowMenu.GetItem(1).SetVisible(true);
                pmRowMenu.GetItem(3).SetVisible(true);
                break;
            case "OtherJobsManual":
                pmRowMenu.GetItem(0).SetVisible(true);
                pmRowMenu.GetItem(5).SetVisible(true);
                break;
            default:
        }
}

function OnGrdJobsGetRowValues(values) {
    try {
        var gridName = "OtherJobs";

        // Si es la grilla de agendados, solo muestra el menu contextual de los procesos manuales no ejecutados.
        if (currentGridSelected.name == "MainContent_grdDailyJobs") {

            if (values[0] == 'Manual' && ((values[1] == 'Ejecutado') || (values[1] == 'Error') || (values[1] == 'Ejecutando'))) {
                HideContextMenu("DailyJobsOnlyRelated");
            }
            else {
                HideContextMenu("DailyJobs" + values[0]);
            }
        }
        else {
            HideContextMenu(gridName + values);
        }
    }
    catch (e) {
    }
}

function grid_ContextMenu(s, e) {
    ClearFocusedRows(s, e);

    pmRowMenu.GetItem(0).SetVisible(false);
    pmRowMenu.GetItem(1).SetVisible(false);
    pmRowMenu.GetItem(2).SetVisible(false);
    pmRowMenu.GetItem(3).SetVisible(false);
    pmRowMenu.GetItem(4).SetVisible(false);
    pmRowMenu.GetItem(5).SetVisible(false);
    pmRowMenu.GetItem(6).SetVisible(false);

    if (e.objectType == "row") {
        globalRowIndex = e.index;
        currentGridSelected = s;
        var row = s.GetRow(globalRowIndex);

        currentGridSelected._selectAllRowsOnPage(false);
        currentGridSelected.SetFocusedRowIndex(-1);
        currentGridSelected.SelectRow(e.index, true);

        var currentPageIndex = globalRowIndex % currentGridSelected.pageRowSize;
        var jobType = currentGridSelected.cpJobType[currentPageIndex];
       
        if (currentGridSelected.name == "MainContent_grdDailyJobs") {
            var jobTriggerStatus = currentGridSelected.cpJobTriggerStatus[currentPageIndex];
            var key2 = jobType + "," + jobTriggerStatus;
            OnGrdJobsGetRowValues(key2.split(','));
        }
        else
            OnGrdJobsGetRowValues(jobType);
                    
        pmRowMenu.ShowAtPos(ASPxClientUtils.GetEventX(e.htmlEvent), ASPxClientUtils.GetEventY(e.htmlEvent))
    }
}
