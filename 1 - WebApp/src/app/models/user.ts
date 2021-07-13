export class UserInfo {

    public userId?: number
    public password?:string

    constructor (
                 public name: string,
                 public lastName: string, 
                //  public email: string,
                 public dni: number, 
                //  public birthdate: Date, 
                 public username: string) 
        {
            this.name = name
            this.lastName = lastName
            // this.email = email
            this.dni = dni
            // this.birthdate = birthdate
            this.username = username
        }

}
