export let guestTopNav: any =
  [
    [
      {link1: "guest", link2: "home", name: "Home"},
      {link1: "guest", link2: "about", name: "About"},
      {link1: "guest", link2: "contacts", name: "Contacts"},
    ],
    [
      {link1: 'guest', link2: 'login', name: 'Sign In'}
    ],
    [
      {profile: null, name: ''}
    ]
  ];

export let registryTopNav: any =
  [
    [
      {link1: "registry", link2: "home", name: "Home"},
      {link1: "registry", link2: "about", name: "About"},
      {link1: "registry", link2: "contacts", name: "Contacts"}
    ],
    [
      {link1: 'registry', link2: 'profile', name: 'Profile'}
    ],
    [
      {profile: this.registryInfo, name: 'Registry Info'}
    ]
  ];

export let patientTopNav: any =
  [
    [
      {link1: "patient", link2: "home", name: "Home"},
      {link1: "patient", link2: "about", name: "About"},
      {link1: "patient", link2: "contacts", name: "Contacts"}
    ],
    [
      {link1: 'patient', link2: 'profile', name: 'Profile'}
    ],
    [
      {profile: this.patientInfo, name: 'Registry Info'}
    ]
  ];

export let doctorTopNav: any =
  [
    [
      {link1: "doctor", link2: "home", name: "Home"},
      {link1: "doctor", link2: "about", name: "About"},
      {link1: "doctor", link2: "contacts", name: "Contacts"}
    ],
    [
      {link1: 'doctor', link2: 'profile', name: 'Profile'}
    ],
    [
      {profile: this.doctorInfo, name: 'Registry Info'}
    ]
  ];

export let accountantTopNav: any =
  [
    [
      {link1: "accountant", link2: "home", name: "Home"},
      {link1: "accountant", link2: "about", name: "About"},
      {link1: "accountant", link2: "contacts", name: "Contacts"}
    ],
    [
      {link1: 'accountant', link2: 'profile', name: 'Profile'}
    ],
    [
      {profile: this.accountantInfo, name: 'Registry Info'}
    ]
  ];
