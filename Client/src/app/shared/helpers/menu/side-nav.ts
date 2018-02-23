export let guestSideNav: any =
  [
    [
      {link1: "guest", link2: "home", name: "Home"},
      {link1: "guest", link2: "home", name: "Home1"},
      {link1: "guest", link2: "home", name: "Home2"},
    ],
    [
      {link1: 'guest', link2: 'login', name: 'Sign In'}
    ],
    [
      {profile: null, name: ''}
    ]
  ];

  export let registrySideNav: any =
    [
      [
        {link1: "registry", link2: "home", name: "Home"},
        {link1: "registry", link2: "appointment", name: "Appointment"},
        {link1: "registry", link2: "register", name: "Registration"}
      ],
      [
        {link1: 'registry', link2: 'profile', name: 'Profile'}
      ],
      [
        {profile: this.registryInfo, name: 'Registry Info'}
      ]
    ];

  export let patientSideNav: any =
    [
      [
        {link1: 'patient', link2: 'home', name: 'Home'},
        {link1: 'patient', link2: 'patient2', name: 'Appointments'},
        {link1: 'patient', link2: 'patient3', name: 'Prescriptions'}
      ],
      [
        {link1: 'patient', link2: 'profile', name: 'Profile'}
      ],
      [
        {profile: this.patientInfo, name: 'Patient Info'}
      ]
    ];
  export let doctorSideNav: any =
    [
      [
        {link1: 'doctor', link2: 'home', name: 'Home'},
        {link1: 'doctor', link2: 'doctor2', name: 'Doctor2'},
        {link1: 'doctor', link2: 'doctor3', name: 'Doctor3'}
      ],
      [
        {link1: 'doctor', link2: 'profile', name: 'Profile'}
      ],
      [
        {profile: this.doctorInfo, name: 'Doctor Info'}
      ]
    ];

  export let accountantSideNav: any =
    [
      [
        {link1: 'accountant', link2: 'home', name: 'Home'},
        {link1: 'accountant', link2: 'accountant2', name: 'Accountant2'},
        {link1: 'accountant', link2: 'accountant3', name: 'Accountant3'}
      ],
      [
        {link1: 'accountant', link2: 'profile', name: 'Profile'}
      ],
      [
        {profile: this.accountantInfo, name: 'Accountant Info'}
      ]
    ];
