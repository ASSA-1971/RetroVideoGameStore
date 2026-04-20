# Retro Video Game Store — COMP2084
**Student:** Aarif Salem Saleh Shammakh Alharthi  
**Student ID:** 200587918

## How to Run This (No Software Required)

### Step 1 — Put the code on GitHub

1. Go to **github.com** and sign in (or create a free account)
2. Click the **+** button (top right) → **New repository**
3. Name it `RetroVideoGameStore`, set it to **Public**, click **Create repository**
4. On the next screen, click **uploading an existing file**
5. Drag and drop ALL the files and folders from this zip into that page
6. Click **Commit changes**

> If GitHub doesn't let you drag folders, upload the zip file itself and ask to extract — or use the GitHub Desktop app if available.

---

### Step 2 — Open GitHub Codespaces (runs in the browser)

1. On your GitHub repo page, click the green **Code** button
2. Click the **Codespaces** tab
3. Click **Create codespace on main**
4. Wait ~2 minutes for it to set up — it will automatically install .NET and run the database migrations

---

### Step 3 — Start the app

Once the Codespace is open, type this in the terminal at the bottom:

```bash
cd RetroVideoGameStore
dotnet run
```

Wait for it to say something like `Now listening on: http://localhost:5000`

Then click **Open in Browser** when Codespaces asks you (or go to the Ports tab and click the link next to port 5000).

---

### Step 4 — Test accounts

| Role | Email | Password |
|------|-------|----------|
| Admin | admin@retrogames.com | Admin1234! |
| Customer | alex@email.com | Customer1234! |
| Customer | sarah@email.com | Customer1234! |

---

### Step 5 — Record your screencast

Use **Loom** (loom.com — free, works in the browser, no download needed):
1. Go to loom.com and sign in with Google
2. Click **New Video** → **Screen & Camera** or **Screen only**
3. Record yourself doing this flow:
   - Browse products (Shop Now → pick a category)
   - Add something to the cart
   - Go to cart, click Checkout
   - Fill in the checkout form (use your own name/address or make one up)
   - On the Payment page, click **Complete Demo Purchase**
   - Show the completed order details page
   - Log out, log in as admin, show the Orders list

---

## What's in the Database

- **4 categories:** NES, SNES, Sega Genesis, Nintendo 64
- **11 products:** Super Mario Bros, Zelda, Sonic, GoldenEye, Ocarina of Time, etc.
- **3 users:** 1 admin + 2 customers (alex and sarah)
- **5 orders** pre-seeded across both customers
