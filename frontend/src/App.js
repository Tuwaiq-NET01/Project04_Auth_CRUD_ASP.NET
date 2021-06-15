import React, { useState, useEffect } from 'react'
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles'
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import { makeStyles } from '@material-ui/core/styles'
import Dashboard from '../src/views/Dashboard'
import Auth from '../src/views/Auth'
import Profile from '../src/views/Profile'
import Account from '../src/views/Account'
import Terms from '../src/views/Terms'
import Privacy from '../src/views/Privacy'
import How from '../src/views/How'
import Shreder from '../src/views/Shreder'
import Assembler from '../src/views/Assembler'
import NavBar from '../src/components/NavBar'
import Footer from '../src/components/Footer'
import { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'

const useStyles = makeStyles(() => ({
  default: {
    fontFamily: 'Ubuntu Mono',
  },
}))

const theme = createMuiTheme({
  palette: {
    primary: {
      main: '#000',
    },
    secondary: {
      main: '#ff5722',
    },
  },
  typography: {
    fontFamily: [
      'Ubuntu Mono',
      '-apple-system',
      'BlinkMacSystemFont',
      '"Segoe UI"',
      'Roboto',
      '"Helvetica Neue"',
      'Arial',
      'sans-serif',
      '"Apple Color Emoji"',
      '"Segoe UI Emoji"',
      '"Segoe UI Symbol"',
    ].join(','),
  },
})

function App() {
  const classes = useStyles()
  const [auth, setAuth] = useState(() => false)

  useEffect(() => {
    const user = JSON.parse(localStorage.getItem('UserData'))
    if (user) setAuth(true)
    else setAuth(false)
    return () => {
      setAuth(false)
    }
  }, [])

  return (
    <div className="App">
      <ThemeProvider theme={theme}>
        <Router>
          <NavBar auth={auth} setAuth={setAuth} />
          <Switch>
            <Route path="/login" component={() => <Auth setAuth={setAuth} />} />
            <Route path="/profile" component={() => <Profile />} />
            <Route path="/account" component={() => <Account />} />
            <Route path="/terms" component={() => <Terms />} />
            <Route path="/privacy" component={() => <Privacy />} />
            <Route path="/how" component={() => <How />} />
            <Route path="/shred" component={() => <Shreder />} />
            <Route path="/assemble" component={() => <Assembler />} />
            <Route path="/" component={() => <Dashboard />} exact />
          </Switch>
          <Footer />
        </Router>
        <ToastContainer toastClassName={classes.default} />
      </ThemeProvider>
    </div>
  )
}

export default App
