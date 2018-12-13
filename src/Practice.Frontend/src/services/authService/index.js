import axios from "axios";

class AuthService {
    static getSession = ({name, group}) => axios.post('/profiles', { name, group })
        .then(({data}) => data)
        .catch(error => console.error(error));

    static getProfile = (session) => axios.get('/profiles', { params: {session} })
        .then(({data}) => data)
        .catch(error => console.error(error));
}

export default AuthService;