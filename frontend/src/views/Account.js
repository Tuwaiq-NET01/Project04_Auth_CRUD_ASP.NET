import React, { useEffect, useState } from 'react'
import { makeStyles, withStyles } from '@material-ui/core/styles'
import { useHistory } from 'react-router-dom'
import { toast } from 'react-toastify'
import Container from '@material-ui/core/Container'
import Paper from '@material-ui/core/Paper'
import Grid from '@material-ui/core/Grid'
import CircularProgress from '@material-ui/core/CircularProgress'
import Checkbox from '@material-ui/core/Checkbox'
import VpnKeyIcon from '@material-ui/icons/VpnKey'
import ButtonBase from '@material-ui/core/ButtonBase'
import StorageIcon from '@material-ui/icons/Storage'
import CloseIcon from '@material-ui/icons/Close'
import Button from '@material-ui/core/Button'
import CardMembershipIcon from '@material-ui/icons/CardMembership'
import Typography from '@material-ui/core/Typography'
import Grow from '@material-ui/core/Grow'
import axios from 'axios'
import Table from '@material-ui/core/Table'
import EventAvailableIcon from '@material-ui/icons/EventAvailable'
import TableBody from '@material-ui/core/TableBody'
import TableCell from '@material-ui/core/TableCell'
import TableContainer from '@material-ui/core/TableContainer'
import TableHead from '@material-ui/core/TableHead'
import TableRow from '@material-ui/core/TableRow'

const StyledTableCell = withStyles((theme) => ({
  head: {
    backgroundColor: theme.palette.common.black,
    color: theme.palette.common.white,
  },
  body: {
    fontSize: 14,
  },
}))(TableCell)

const StyledTableRow = withStyles((theme) => ({
  root: {
    '&:nth-of-type(odd)': {
      backgroundColor: theme.palette.action.hover,
    },
  },
}))(TableRow)

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  rootForm: {
    '& > *': {
      margin: theme.spacing(1),
      width: '75%',
    },
  },
  paper: {
    padding: theme.spacing(2),
    marginBottom: theme.spacing(1),
    marginTop: theme.spacing(6),
    textAlign: 'center',
    color: theme.palette.text.secondary,
    borderRadius: theme.spacing(2),
    minHeight: theme.spacing(25),
  },
  large: {
    width: theme.spacing(23),
    height: theme.spacing(8),
    padding: theme.spacing(4),
    margin: 'auto',
  },
  divider: {
    borderBottom: 'solid',
    borderWidth: '1px',
    color: '#ff5722',
    padding: '0.5rem',
    marginBottom: '2rem',
    margin: 'auto',
    width: '1.5rem',
  },
  space: {
    paddingTop: '1.5rem',
    paddingBottom: '1.5rem',
    fontSize: '0.8rem',
    textAlign: 'center',
  },
  icon: {
    paddingTop: 10,
    paddingBottom: 10,
  },
  btn: {
    marginTop: theme.spacing(1),
  },
  infoBlock: {
    display: 'flex',
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
  },
  infoText: {
    marginTop: theme.spacing(2),
    color: '#000',
    fontSize: '1.5rem',
  },
  cnkChild: {
    width: 50,
    height: 50,
    paddingRight: 200,
  },
  cnkParent: {
    width: '95%',
    height: 100,
    textAlign: 'center',
    display: 'block',
  },
  cnkText: {
    marginTop: theme.spacing(2),
    color: '#32CD32',
    fontSize: '0.9rem',
  },
  loading: {
    marginTop: theme.spacing(15),
    marginBottom: theme.spacing(15),
  },
}))

const AlertSuccess = (msg) => {
  toast.success(`🚀 ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

const AlertError = (msg) => {
  toast.error(`💩 ${msg}`, {
    position: 'top-right',
    autoClose: 2000,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
  })
}

export default function Account({ setAuth }) {
  const history = useHistory()
  const user = JSON.parse(localStorage.getItem('UserData'))
  if (!user) history.push('/login')
  const config = {
    headers: {
      Authorization: `Bearer ${user && user.token}`,
      'Content-Type': 'application/json',
    },
  }
  document.title = user && user.name.split(' ')[0] + "'s Account"
  const classes = useStyles()
  const [loading, setLoading] = useState(() => true)
  const [checked, setChecked] = useState(() => false)
  const [userData, setUserData] = useState({})
  const [userLogs, setUserLogs] = useState({})

  const handleChange = (event) => {
    setChecked(event.target.checked)
  }

  const reassemble = (file) => {
    localStorage.setItem('FileName', JSON.stringify(file))
    history.push('/assemble')
  }

  const closeAccount = () => {
    history.push('/login')
    axios.delete(`/api/user/${user.id}`, config).then((res) => {
      if (res.status === 200) {
        localStorage.setItem('UserData', null)
        setAuth(false)
        AlertSuccess('Your account is closed.')
      }
    })
  }

  useEffect(() => {
    if (user) {
      axios(`/api/user/${user.id}`, config)
        .then((res) => {
          if (res.status === 200) setUserData(res.data.user)
        })
        .catch((error) => {
          AlertError(`${error.response.status} error occured.`)
          history.push('/login')
        })

      axios(`/api/logs/${user.id}`, config)
        .then((res) => {
          if (res.status === 200) setUserLogs(res.data.logs)
          setTimeout(() => setLoading(false), 500)
        })
        .catch((error) => {
          AlertError(`${error.response.status} error occured.`)
          history.push('/login')
        })
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
    <Grow direction="up" in={true}>
      <Container className={classes.root}>
        <Grid justify="center" container spacing={2}>
          <Grid item xs={12} lg={10} md={8}>
            <Paper className={classes.paper} elevation={20}>
              {loading ? (
                <CircularProgress
                  className={classes.loading}
                  color="secondary"
                />
              ) : (
                <>
                  <Typography color="secondary" variant="h5" nowrap="true">
                    {user && user.name.split(' ')[0] + "'s "}
                    <span style={{ color: '#000' }}>{'Account'}</span>
                  </Typography>
                  <div className={classes.divider} />
                  <Grid
                    container
                    justify="center"
                    spacing={2}
                    style={{ marginTop: 30 }}
                  >
                    <Grid item xs={4}>
                      <ButtonBase centerRipple={true}>
                        <div className={classes.infoBlock}>
                          <CardMembershipIcon
                            fontSize="large"
                            color="primary"
                          />
                          <Typography
                            variant="h6"
                            nowrap="true"
                            className={classes.infoText}
                          >
                            <span style={{ color: '#ff5722' }}>
                              {userData && userData.accountType}
                            </span>{' '}
                            Subscription
                          </Typography>
                        </div>
                      </ButtonBase>
                    </Grid>
                    <Grid item xs={4}>
                      <ButtonBase centerRipple={true}>
                        <div className={classes.infoBlock}>
                          <EventAvailableIcon
                            fontSize="large"
                            color="primary"
                          />
                          <Typography
                            variant="h6"
                            nowrap="true"
                            className={classes.infoText}
                          >
                            {userData && userData.creationDate.split('-')[1]}
                            {'/'}
                            <span style={{ color: '#ff5722' }}>
                              {userData && userData.creationDate.split('-')[0]}
                            </span>
                          </Typography>
                        </div>
                      </ButtonBase>
                    </Grid>
                    <Grid item xs={4}>
                      <ButtonBase centerRipple={true}>
                        <div className={classes.infoBlock}>
                          <StorageIcon fontSize="large" color="primary" />
                          <Typography
                            variant="h6"
                            nowrap="true"
                            className={classes.infoText}
                          >
                            <span style={{ color: '#ff5722' }}>
                              {' '}
                              {(
                                userData && userData.currentQuota * 0.000001
                              ).toFixed(3)}
                            </span>
                            {'/'}
                            {parseInt(userData && userData.totalQuota) + ' MB'}
                          </Typography>
                        </div>
                      </ButtonBase>
                    </Grid>
                  </Grid>
                </>
              )}
            </Paper>
          </Grid>
          <Grid item xs={12} lg={10} md={8}>
            <Paper className={classes.paper} elevation={20}>
              <>
                {loading ? (
                  <CircularProgress
                    className={classes.loading}
                    color="secondary"
                  />
                ) : (
                  <>
                    <Typography color="secondary" variant="h5" nowrap="true">
                      {user && user.name.split(' ')[0] + "'s "}
                      <span style={{ color: '#000' }}>{'Logs'}</span>
                    </Typography>
                    <div className={classes.divider} />
                    <Grid container justify="center" spacing={2}>
                      <Grid item xs={12}>
                        {(userLogs && userLogs.length) >= 1 ? (
                          <TableContainer>
                            <Table>
                              <TableHead>
                                <TableRow>
                                  <StyledTableCell>Log Id</StyledTableCell>
                                  <StyledTableCell align="center">
                                    Ref File
                                  </StyledTableCell>
                                  <StyledTableCell align="center">
                                    Ori File
                                  </StyledTableCell>
                                  <StyledTableCell align="center">
                                    Size
                                  </StyledTableCell>
                                  <StyledTableCell align="center">
                                    Time
                                  </StyledTableCell>
                                  <StyledTableCell align="center">
                                    Date
                                  </StyledTableCell>
                                  <StyledTableCell align="center">
                                    Reassemble
                                  </StyledTableCell>
                                </TableRow>
                              </TableHead>
                              <TableBody>
                                {userLogs.map((log) => (
                                  <StyledTableRow key={log.id}>
                                    <StyledTableCell component="th" scope="row">
                                      {log.id + 1}
                                    </StyledTableCell>
                                    <StyledTableCell align="center">
                                      {log.refFileName}
                                    </StyledTableCell>
                                    <StyledTableCell align="center">
                                      {log.oriFileName}
                                    </StyledTableCell>
                                    <StyledTableCell align="center">
                                      {(log.fileSize * 0.000001).toFixed(3)} MB
                                    </StyledTableCell>
                                    <StyledTableCell align="center">
                                      {(log.operationTimes / 1000).toFixed(3)} s
                                    </StyledTableCell>
                                    <StyledTableCell align="center">
                                      {log.timeStamp}
                                    </StyledTableCell>
                                    <StyledTableCell align="center">
                                      <Button
                                        variant="contained"
                                        size="small"
                                        style={{
                                          backgroundColor: '#32CD32',
                                        }}
                                        onClick={() =>
                                          reassemble(log.refFileName)
                                        }
                                      >
                                        <VpnKeyIcon size="small" />
                                      </Button>
                                    </StyledTableCell>
                                  </StyledTableRow>
                                ))}
                              </TableBody>
                            </Table>
                          </TableContainer>
                        ) : (
                          <Typography style={{ paddingTop: 20 }}>
                            Your logs will appear here.
                          </Typography>
                        )}
                      </Grid>
                    </Grid>
                  </>
                )}
              </>
            </Paper>
          </Grid>
          <Grid item xs={12} lg={10} md={8}>
            <Paper className={classes.paper} elevation={20}>
              <>
                {loading ? (
                  <CircularProgress
                    className={classes.loading}
                    color="secondary"
                  />
                ) : (
                  <>
                    <Typography color="secondary" variant="h5" nowrap="true">
                      Account Closure
                    </Typography>
                    <div className={classes.divider} />
                    <Grid container justify="center" spacing={2}>
                      <Grid item xs={1}>
                        <Checkbox
                          checked={checked}
                          onChange={handleChange}
                          style={{ color: checked ? '#b31b1b' : 'gray' }}
                        />
                      </Grid>
                      <Grid item xs={11}>
                        <Typography
                          style={{
                            marginTop: 8,
                            color: checked ? '#b31b1b' : 'gray',
                            cursor: 'pointer',
                          }}
                          align="justify"
                          onClick={() => setChecked(!checked)}
                        >
                          I hereby authorize Bitchunk to close my account. I
                          have noted that all my data will be permanently
                          deleted.
                        </Typography>
                      </Grid>
                      <Grid item xs={6}>
                        <Button
                          fullWidth
                          disabled={checked ? false : true}
                          variant="contained"
                          style={{
                            backgroundColor: checked ? '#b31b1b' : 'gray',
                          }}
                          onClick={() => {
                            closeAccount()
                          }}
                        >
                          <span style={{ color: '#fff' }}>Close Account</span>
                        </Button>
                      </Grid>
                      <Grid item xs={6}>
                        <Button
                          fullWidth
                          variant="contained"
                          color="primary"
                          onClick={() => {
                            history.push('/')
                          }}
                        >
                          <CloseIcon />
                        </Button>
                      </Grid>
                    </Grid>
                  </>
                )}
              </>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </Grow>
  )
}
