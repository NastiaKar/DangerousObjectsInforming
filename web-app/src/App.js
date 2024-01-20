import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import User from "./components/User";

function App() {
  return (
    <Provider store={store}>
      <User />
    </Provider>
  );
}

export default App;
