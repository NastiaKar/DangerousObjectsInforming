import axios from "axios";

const baseUrl = "https://localhost:7144/"



export default {
    user(url = baseUrl + 'Register'){
        return {
            create : newRecord => axios.post(url, newRecord),
        }
    }
}