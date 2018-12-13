import axios from "axios";

class AuthService {
    static getSession = ({name, group}) => axios.post('/profiles', { name, group })
        .then(({data}) => data);

    static getProfile = (session) => axios.get('/profiles', { params: {session} })
        .then(({data}) => data);
}

export default AuthService;