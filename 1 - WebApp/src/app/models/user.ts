export class UserDto {
    public userId: number = -1
    public name: string = ''
    public lastName: string = ''
    public username: string = ''
    public dni: number = -1
    public creationDate: Date = new Date
    public statusId: number = -1
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
