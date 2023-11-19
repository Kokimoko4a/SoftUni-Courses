function createObj(employees){

  for (const em of employees) {
    console.log(`Name: ${em} -- Personal Number: ${em.length}`)
  }
}

createObj([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    )

