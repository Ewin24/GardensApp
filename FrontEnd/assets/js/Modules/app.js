let getJsonData = async () => {
    const jsonUrl = '/FrontEnd/assets/json/fields.json';

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
        let fields = jsonData.entities[selectedEntity].fields;
        let type;
        fields.forEach(element => {
            if (element.name === selectedProp) {
                type = element.type;
            }
        });
        console.log(type);
        conditionValue.type = type;
    });
}

function getQuery() {
    const selectedEntity = document.getElementById("entity").value;
    const selectedProp = document.getElementById("conditionField").value;
    const selectedType = document.getElementById("conditionType").value;
    const conditionValue = document.getElementById("conditionValue").value;

    // Puedes utilizar estos valores para construir tu consulta LINQ
    console.log(`Entidad seleccionada: ${selectedEntity}`);
    console.log(`Campo de Condición: ${selectedProp}`);
    console.log(`Tipo de Condición: ${selectedType}`);
    console.log(`Valor de Condición: ${conditionValue}`);


    const miVariable =
    {
        selectedEntity,
        selectedProp,
        selectedType,
        conditionValue
    };

    // let jsonstring = JSON.stringify(miVariable);

    const endpointUrl = "http://127.0.0.1:5019/CustomQuery/";

    fetch(endpointUrl, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ variableEnviada: miVariable }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`Error: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            // Realiza algo con la respuesta del servidor
            console.log('Respuesta del servidor:', data);
        })
        .catch(error => {
            console.error('Error al realizar la solicitud:', error);
        });
}

loadFields();