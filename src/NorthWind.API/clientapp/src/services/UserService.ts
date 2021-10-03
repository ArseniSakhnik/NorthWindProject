// export class UserService {
//     constructor() {
//         this._user = null;
//     }
//
//     loggedIn() {
//         return !!this._user;
//     }
//
//     hasAdminRole() {
//         return this._user !== null && this._user.roles.some(role => role.id === 1);
//     }
//
//     async logIn(userName, password, rememberMe = false) {
//         return fetch('api/account/login', {
//             method: 'POST',
//             credentials: 'include',
//             headers: {
//                 'Accept': 'application/json, text/plain, */*',
//                 'Content-Type': 'application/json'
//             },
//             body: JSON.stringify({
//                 userName,
//                 password,
//                 rememberMe
//             })
//         })
//             .then(response => {
//                 if (response.ok) {
//                     this._user = null;
//                     return {
//                         isOk: true
//                     }
//                 }
//                 return response.text().then(text => {
//                     return {
//                         isOk: false,
//                         message: "Ошибка авторизации: " + text
//                     }
//                 })
//             })
//             .catch((e) => {
//                 console.log(e)
//                 return {
//                     isOk: false,
//                     message: "Ошибка авторизации"
//                 }
//             })
//     }
// }


import {HttpContext} from '@/services/HttpContext'

export class UserService extends HttpContext {
    user: object | null = null

    constructor() {
        super('/account')
    }

    async logIn(userName: string, password: string) {
        return this._post('/login', {
            userName,
            password
        })
            .then(response => {
                if (response.ok) {
                    this.user = null
                    return {
                        isOk: true
                    }
                }
                return response.text().then(text => {
                    return {
                        isOk: false,
                        message: 'Ошибка авторизации ' + text
                    }
                })
            })
            .catch(e => {
                console.log(e)
                return {
                    isOk: false,
                    message: 'Ошибка авторизации'
                }
            })
    }
}