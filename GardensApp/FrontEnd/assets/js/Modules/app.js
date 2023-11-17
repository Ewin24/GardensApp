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

    let selectedEntity;
    let selectedProp;
    const conditionField = document.getElementById("conditionField");
    const conditionTypeSelector = document.getElementById("conditionType");
    const conditionValue = document.getElementById("conditionValue");


    // Limpiar los campos existentes
    conditionField.innerHTML = "";
    conditionField.innerHTML = "";
    conditionTypeSelector.innerHTML = "";

    // cargar propiedades entidad segun entidad
    const entityField = document.getElementById("entity");
    entityField.addEventListener('input', () => {
        selectedEntity = document.getElementById("entity").value;
        const props = jsonData.entities[selectedEntity].fields;
        propField.innerHTML = "";
        props.map(field => {
            conditionField.insertAdjacentHTML("afterbegin", `
                <option value="${field.name}">${field.name}</option>
                `);
        });
    })

    // cargar condición
    const conditionTypes = jsonData.conditionTypes;
    conditionTypes.forEach(type => {
        const option = document.createElement("option");
        option.value = type;
        option.text = type;
        conditionTypeSelector.insertAdjacentElement("afterbegin", option);
    });

    // Cargar input segun el tipo de dato del campo de la entidad
    const propField = document.getElementById("conditionField");
    propField.addEventListener('input', () => {
        selectedProp = propField.value;
        const selectedFieldType = jsonData.entities[selectedEntity].fields[selectedProp];
        console.log(selectedFieldType);
        conditionValue.insertAdjacentHTML("afterbegin", `<input type="${selectedFieldType}" id="conditionValue" name="conditionValue">`);
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