export let guestTopNav: any =
  [
    [
      {link1: "guest", link2: "home", name: "Home"},
      {link1: "guest", link2: "guest1", name: "Guest1"},
      {link1: "guest", link2: "guest2", name: "Guest2"}
    ],
    [
      {link1: "guest", link2: "login", name: "Sign In"}
    ],
    [
      {profile: null, name: ""}
    ]
  ];

  export let registryTopNav: any =
    [
      [
        {link1: "registry", link2: "home", name: "Home"},
        {link1: "registry", link2: "register", name: "Patient Registration"},
        {link1: "registry", link2: "registry3", name: "Registry3"}
      ],
      [
        {link1: "registry", link2: "profile", name: "Profile"}
      ],
      [
        {profile: this.registryInfo, name: "Registry Info"}
      ]
    ];

  export let patientTopNav: any =
    [
      [
        {link1: "patient", link2: "home", name: "Home"},
        {link1: "patient", link2: "patient2", name: "Patient2"},
        {link1: "patient", link2: "patient3", name: "Patient3"}
      ],
      [
        {link1: "patient", link2: "profile", name: "Profile"}
      ],
      [
        {profile: this.patientInfo, name: "Patient Info"}
      ]
    ];
  export let doctorTopNav: any =
    [
      [
        {link1: "doctor", link2: "home", name: "Home"},
        {link1: "doctor", link2: "doctor2", name: "Doctor2"},
        {link1: "doctor", link2: "doctor3", name: "Doctor3"}
      ],
      [
        {link1: "doctor", link2: "profile", name: "Profile"}
      ],
      [
        {profile: this.doctorInfo, name: "Doctor Info"}
      ]
    ];

  export let accountantTopNav: any =
    [
      [
        {link1: "accountant", link2: "home", name: "Home"},
        {link1: "accountant", link2: "accountant2", name: "Accountant2"},
        {link1: "accountant", link2: "accountant3", name: "Accountant3"}
      ],
      [
        {link1: "accountant", link2: "profile", name: "Profile"}
      ],
      [
        {profile: this.accountantInfo, name: "Accountant Info"}
      ]
    ];
