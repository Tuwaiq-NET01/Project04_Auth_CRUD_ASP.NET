import React, { useState, useEffect } from 'react'
import { makeStyles } from '@material-ui/core/styles'
import AppBar from '@material-ui/core/AppBar'
import Toolbar from '@material-ui/core/Toolbar'
import AccountCircle from '@material-ui/icons/AccountCircle'
import Typography from '@material-ui/core/Typography'
import Button from '@material-ui/core/Button'
import IconButton from '@material-ui/core/IconButton'
import Avatar from '@material-ui/core/Avatar'
import { toast } from 'react-toastify'
import LogoImg from '../assets/img/logo.png'
import HomeIcon from '@material-ui/icons/Home'
import MenuItem from '@material-ui/core/MenuItem'
import Menu from '@material-ui/core/Menu'
import SettingsIcon from '@material-ui/icons/Settings'
import HowToRegIcon from '@material-ui/icons/HowToReg'
import HelpIcon from '@material-ui/icons/Help'
import ExitToAppIcon from '@material-ui/icons/ExitToApp'
import { Link } from 'react-router-dom'

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    marginBottom: theme.spacing(8),
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
    fontSize: '1.2rem',
  },
  logo: {
    marginRight: theme.spacing(1),
    width: 38,
    height: 38,
  },
  icon: {
    marginRight: theme.spacing(1),
  },
}))

const AlertInfo = (msg) => {
  toast.info(`✌ ${msg}`, {
    position: 'top-right',
    autoClose: 1500,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

export default function NavBar({ auth, setAuth }) {
  const user = JSON.parse(localStorage.getItem('UserData'))
  const classes = useStyles()
  const [anchorEl, setAnchorEl] = useState(() => null)
  const open = Boolean(anchorEl)

  const handleMenu = (event) => {
    setAnchorEl(event.currentTarget)
  }

  const handleClose = () => {
    setAnchorEl(null)
  }

  useEffect(() => {}, [auth])

  return (
    <div className={classes.root}>
      <AppBar position="fixed">
        <Toolbar>
          <IconButton
            edge="start"
            className={classes.menuButton}
            color="inherit"
            component={Link}
            to={'/assemble'}
          >
            <HomeIcon />
          </IconButton>
          <Avatar alt="Bitchunk Logo" className={classes.logo} src={LogoImg} />
          <Typography variant="h6" className={classes.title}>
            Bitchunk™
          </Typography>
          <>
            {auth ? (
              <div>
                <IconButton
                  aria-label="account of current user"
                  aria-controls="menu-appbar"
                  aria-haspopup="true"
                  onClick={handleMenu}
                  color="inherit"
                >
                  <SettingsIcon />
                </IconButton>
                <Menu
                  id="menu-appbar"
                  anchorEl={anchorEl}
                  anchorOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                  }}
                  keepMounted
                  transformOrigin={{
                    vertical: 'top',
                    horizontal: 'right',
                  }}
                  open={open}
                  onClose={handleClose}
                >
                  <MenuItem
                    component={Link}
                    to={'/profile'}
                    onClick={handleClose}
                  >
                    <HowToRegIcon color="secondary" className={classes.icon} />{' '}
                    {user.name.split(' ')[0]}
                  </MenuItem>
                  <MenuItem
                    component={Link}
                    to={'/account'}
                    onClick={handleClose}
                  >
                    <AccountCircle color="secondary" className={classes.icon} />
                    Account
                  </MenuItem>
                  <MenuItem component={Link} to={'/how'} onClick={handleClose}>
                    <HelpIcon color="secondary" className={classes.icon} />
                    How It Works
                  </MenuItem>
                  <MenuItem
                    component={Link}
                    to={'/login'}
                    onClick={() => {
                      setAuth(false)
                      localStorage.setItem('UserData', null)
                      AlertInfo(`Goodbye.`)
                      handleClose()
                    }}
                  >
                    <ExitToAppIcon color="secondary" className={classes.icon} />
                    Logout
                  </MenuItem>
                </Menu>
              </div>
            ) : (
              <Button color="inherit" component={Link} to={'/login'}>
                Login
              </Button>
            )}
          </>
        </Toolbar>
      </AppBar>
    </div>
  )
}
