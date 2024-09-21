<template>
	<button class="button">
		<slot>
		</slot>
	</button>
</template>

<script>
export default {
	name: 'my-button',
}
</script>

<style scoped>
.button {
  font-size: 14px;
  padding: 8px 15px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 5px;
  transition: background-color 0.2s ease;
  cursor: pointer;
  user-select: none;
}

.button:hover {
  background-color: #0069d9;
}
</style>
