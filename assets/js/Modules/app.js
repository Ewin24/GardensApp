let getJsonData = async () => {
    const jsonUrl = '/assets/json/fields.json';

    try {
        const response = await fetch(jsonUrl);

        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }

        const data = await response.json();
        console.log('Datos del JSON externo:', data);
        return data;
    } catch (error) {
        console.error('Error al obtener el JSON externo:', error);
    }
};

async function loadFields() {
    let jsonData = await getJsonData();//datos json

    const selectedEntity = document.getElementById("entity").value;
    const selectedField = document.getElementById("conditionField").value;
    const conditionField = document.getElementById("conditionField");
    const conditionTypeSelector = document.getElementById("conditionType");
    const conditionValue = document.getElementById("conditionValue");


    // Limpiar los campos existentes
    conditionField.innerHTML = "";
    conditionTypeSelector.innerHTML = "";

    // Obtener campos y tipos de condición para la entidad seleccionada
    const fields = jsonData.entities[selectedEntity].fields;
    const conditionTypes = jsonData.conditionTypes;

    // Crear opciones de campo y agregarlas al contenedor
    fields.map(field => {
        conditionField.insertAdjacentHTML("afterbegin", `
        <option value="${field.name}">${field.name}</option>
        `);
    });

    // Presonalizar entrada segun el tipo de dato del campo de la entidad
    const selectedFieldType = jsonData.entities[selectedEntity].fields[selectedField].type;
    // Agregar un nuevo elemento input al contenedor
    conditionValue.insertAdjacentHTML("afterbegin", `<input type="${selectedFieldType}" id="conditionValue" name="conditionValue">`);

    // Crear opciones de tipo de condición y agregarlas al selector
    conditionTypes.forEach(type => {
        const option = document.createElement("option");
        option.value = type;
        option.text = type;
        conditionTypeSelector.insertAdjacentElement("afterbegin", option);
    });
}

function getQuery() {
    const selectedEntity = document.getElementById("entity").value;
    const selectedFields = Array.from(document.querySelectorAll('input[name="fields"]:checked')).map(checkbox => checkbox.value);
    const conditionField = document.getElementById("conditionField").value;
    const conditionType = document.getElementById("conditionType").value;
    const conditionValue = document.getElementById("conditionValue").value;

    // Puedes utilizar estos valores para construir tu consulta LINQ
    console.log(`Entidad seleccionada: ${selectedEntity}`);
    console.log(`Campos seleccionados: ${selectedFields.join(", ")}`);
    console.log(`Campo de Condición: ${conditionField}`);
    console.log(`Tipo de Condición: ${conditionType}`);
    console.log(`Valor de Condición: ${conditionValue}`);
}

loadFields();