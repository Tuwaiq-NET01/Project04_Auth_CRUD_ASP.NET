import React from 'react'

export default function Header() {
    return (
        <div>

            {/* <header className="p-3 mb-3 border-bottom">
                <div class="container">

                    <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">



                        <a href="/" class="d-flex align-items-center mb-2 mb-lg-0 text-dark text-decoration-none">
                            <svg class="bi me-2" width="40" height="32" role="img" aria-label="Bootstrap"></svg></a>

                        <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
                            <li><a href="#" class="nav-link px-2 link-secondary">Overview</a></li>
                            <li><a href="#" class="nav-link px-2 link-dark">Inventory</a></li>
                            <li><a href="#" class="nav-link px-2 link-dark">Customers</a></li>
                            <li><a href="#" class="nav-link px-2 link-dark">Products</a></li>
                        </ul>




                        <form class="col-12 col-lg-auto mb-3 mb-lg-0 me-lg-3">
                            <input type="search" class="form-control" placeholder="Search..." aria-label="Search" />
                        </form>


                        <div class="dropdown text-end">
                            <a href="#" class="d-block link-dark text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                                <img src="https://github.com/mdo.png" alt="mdo" width="32" height="32" class="rounded-circle" />
                            </a>
                            <ul class="dropdown-menu text-small" aria-labelledby="dropdownUser1">
                                <li><a class="dropdown-item" href="#">New project...</a></li>
                                <li><a class="dropdown-item" href="#">Settings</a></li>
                                <li><a class="dropdown-item" href="#">Profile</a></li>
                                <li><hr class="dropdown-divider" /></li>
                                <li><a class="dropdown-item" href="#">Sign out</a></li>
                            </ul>
                        </div>
                    </div>


                </div>
            </header> */}

                <header class="site-header sticky-top py-1">
                <nav class="container d-flex flex-column flex-md-row justify-content-between">
                    <a class="py-2" href="#" aria-label="Product">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="d-block mx-auto" role="img" viewBox="0 0 24 24"><title>Product</title><circle cx="12" cy="12" r="10"/><path d="M14.31 8l5.74 9.94M9.69 8h11.48M7.38 12l5.74-9.94M9.69 16L3.95 6.06M14.31 16H2.83m13.79-4l-5.74 9.94"/></svg>
                    </a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Tour</a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Product</a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Features</a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Enterprise</a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Support</a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Pricing</a>
                    <a class="py-2 d-none d-md-inline-block" href="#">Cart</a>
                </nav>
                </header>

        </div>
    )
}
