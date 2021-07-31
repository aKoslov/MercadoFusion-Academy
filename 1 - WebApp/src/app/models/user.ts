export class UserDto {
    public userId: number = -1
    public name: string = ''
    public surname: string = ''
    public username: string = ''
    public documentNumber: number = -1
    public creationDate: Date = new Date
    public statusId: number = -1
    public userType: number = 3
    constructor(userId: number,
                userType: number)  {
                    this.userId = userId 
                    this.userType = userType
                }
}

export class UserSession {
    constructor(public userId:number,
                public userType: number) 
                {
                    this.userId = userId
                    this.userType = userType
                }
}

export class UserLogin {
    constructor (public username: string,
                 public password: string) {
                     this.username = username
                     this.password = password
                 }
}

export class UserForSignup {

    public userId?: number
    public password?:string

    constructor (
                 public name: string,
                 public lastName: string, 
                 public dni: number, 
                 public username: string) 
        {
            this.name = name 
            this.lastName = lastName
            this.dni = dni
            this.username = username
        }
}

export class UsersListResponse {
    constructor (
                public list: UserDto[],
                public count: number)
        {
            this.list = list
            this.count = count
        }
}

export class Session {
    constructor(public userId: number,
                public userType: number)
                {
                    this.userId = userId
                    this.userType = userType
                }
}
