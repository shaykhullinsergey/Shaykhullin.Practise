import React, {Component} from 'react';
import AuthTemplate from "./authTemplate";
import AuthService from "../../services/authService";

class Auth extends Component {
    constructor(props) {
        super(props);

        this.state = {
            formData: {
                name: '',
                group: ''
            },
            formErrors: []
        };
    }

    componentDidMount() {
        try {
            const session = JSON.parse(localStorage.getItem('education_recourse_session')).session;
            this.props.history.push(`/lectures/${session}`);
        }
        catch (e) {

        }
    }

    onChange = ({name, value}) => {
        this.setState({
            formData: {...this.state.formData, [name]: value}
        });
    };

    onSubmit = () => {
        const {formData} = this.state;
        AuthService.getSession(formData)
            .then((data) => {
                localStorage.setItem('education_recourse_session', JSON.stringify(data));
                this.props.history.push(`/lectures/${data.session}`);
            })
            .catch(error => console.log(error.response.data));
    };

    render() {
        const {formData, formErrors} = this.state;
        return <AuthTemplate
            formData={formData}
            formErrors={formErrors}
            onChange={this.onChange}
            onSubmit={this.onSubmit}
        />
    }
}

export default Auth;
