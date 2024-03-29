
let companiesContainer = document.querySelector('#companiesContainer');

let companyId;
let companyTitle = document.querySelector('#companyTitle');
let companyCreateDate = document.querySelector('#companyCreateDate');

let clearFormBtn = document.querySelector('#clearFormBtn');
let createCompanyBtn = document.querySelector('#createCompanyBtn');
let deleteBtn = document.querySelector('#deleteCompanyBtn');
let updateBtn = document.querySelector('#updateCompanyBtn');

function getAllCompanies() {
    fetch('https://localhost:7069/api/companies')
        .then(response => response.json())
        .then(data => displayCompanies(data.result))
}
getAllCompanies();


function getCompanyById(id) {
    fetch(`https://localhost:7069/api/companies/${id}`)
        .then(response => response.json())
        .then(data => {
            displayCompanyInForm(data.result)

            //ვშლით კომპანიას ფორმის შევსების შემდეგ
            deleteBtn.addEventListener('click', function () {
                fetch(`https://localhost:7069/api/companies/${id}`, {
                    method: 'DELETE',
                    headers: {
                        'content-type': 'application/json'
                    }
                })
                    .then(response => response.json()) // Need to invoke json() to parse the response
                    .then(data => {
                        clearForm();
                        alert('Company deleted successfully');
                        getAllCompanies();
                    }) // Log the parsed JSON data
                    .catch(error => console.error('Error:', error)); // Catch any errors
            });
        }
        )
}


function displayCompanyInForm(company) {
    companyId = company.id;
    companyTitle.value = company.title;
    companyCreateDate.value = company.createDate;

    const dateobject = new Date(company.createDate);
    const dateResult = dateobject.toISOString().split('T')[0];

    companyCreateDate.value = dateResult;
}


function displayCompanies(companies) {
    let allCompanies = '';
    companies.forEach(company => {
        const companyElement = `
            <div class="col-lg-4 col-md-6 col-sm-12 mt-2">
                <div class="card main-card" data-id=${company.id}>
                    <div class="card-body">
                    <h5 class="card-title">${company.title}</h5>
                    <p class="card-text">${company.createDate}</p>
                    </div>
                </div>
            </div>
        `
        allCompanies += companyElement;
    });

    companiesContainer.innerHTML = allCompanies;

    document.querySelectorAll('.main-card').forEach(card => {
        card.addEventListener('click', function () {
            populateForm(card.dataset.id)
        })
    })

}

function populateForm(id) {
    getCompanyById(id);
}




createCompanyBtn.addEventListener('click', function () {
    createCompany(companyTitle.value, companyCreateDate.value)
})

function createCompany(title, createDate) {
    const body = {
        "title": title,
        "createDate": createDate
    }

    fetch('https://localhost:7069/api/companies', {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            'content-type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            if (data.isSuccess === true) {
                clearForm();
                alert('Company added successfully');
                getAllCompanies();
            }
            else {
                alert('Something went wrong')
            }
        })
        .catch(error => console.error(error))

}


clearFormBtn.addEventListener('click', function () {
    clearForm();
})

function clearForm() {
    companyTitle.value = '';
    companyCreateDate.value = '';
}



function updateCompany(id, title, createDate) {
    const body = {
        "id": id,
        "title": title,
        "createDate": createDate
    }

    fetch('https://localhost:7069/api/companies', {
        method: 'PUT',
        body: JSON.stringify(body),
        headers: {
            'content-type': 'application/json'
        }
    })
        .then(response => response.json()) // Need to invoke json() to parse the response
        .then(data => {
            clearForm();
            //TODO Check status before alert...
            alert('Company updated successfully');
            getAllCompanies();
        }) // Log the parsed JSON data
        .catch(error => console.error('Error:', error)); // Catch any errors
}


updateBtn.addEventListener('click', function (e) {
    console.log(e);
    updateCompany(companyId, companyTitle.value, companyCreateDate.value);
})